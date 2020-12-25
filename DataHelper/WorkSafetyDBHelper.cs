using AutoMapper;
using DataHelper.Entity.WSEntities;
using DataHelper.Models;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DataHelper
{
    public class WorkSafetyDBHelper
    {

        static work_safety3Context _context = new work_safety3Context();
        readonly Dispatcher dispatcher;
        TextBox _box;
        IMapper _mapper;
        public WorkSafetyDBHelper()
        {

        }
        public WorkSafetyDBHelper(Dispatcher dispatcher, TextBox box)
        {
            this.dispatcher = dispatcher;
            _box = box;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonFileDto, PersonFile>();
                cfg.CreateMap<OrgInfoDto, OrganizationInfo>();
            });
            _mapper = configuration.CreateMapper();
        }
        /// <summary>
        /// 批量插入用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task InsertUsersAsync(List<WSUserDto> users)
        {
            var data = new List<User>();
            foreach (var user in users)
            {
                // 根据姓名和手机号判断是否存在
                if (_context.User.Any(u => u.Username.Equals(user.Phone) && u.Mobile.Equals(user.Phone)))
                {
                    _box.AppendText($"{user.RealName} {user.Phone} 已存在!\r\n");
                    _box.ScrollToEnd();
                    continue;
                }
                // 查询关联字段内容
                var province = user.Province.Replace("省", "");
                var provinceId = _context.OuRel.Where(o => o.OuName.Equals(province))
                    .Select(s => s.OuId)
                    .FirstOrDefault();
                var city = user.City.Replace("市", "");
                var cityId = _context.WorkOrganization.Where(o => o.City.Equals(city))
                    .Select(o => o.CityId)
                    .FirstOrDefault();

                var role = _context.Role.Where(r => r.Name.Equals(user.RoleName))
                    .FirstOrDefault();
                if (role == null)
                {
                    _box.AppendText($"{user.RoleName} 不存在!\r\n");
                    continue;
                }
                // 构造并插入内容
                var wsUser = new User
                {
                    Username = user.Phone.Trim(),
                    CityId = cityId,
                    CityName = city,
                    CreateTime = DateTime.Now,
                    CreatorName = "tool bulk create",
                    IsChange = 0,
                    IsLogin = 0,
                    Password = "Sysupsafe@0901",
                    PasswordMd5 = "1b1d2129c6bec40d687adedcb9c1c4dd",
                    RealName = user.RealName.Trim(),
                    Mobile = user.Phone.Trim(),
                    RoleId = role.Id,
                    RoleLevel = role.Level,
                    RoleName = user.RoleName.Trim(),
                    ProvinceId = provinceId,
                    ProvinceName = province,
                    DepartmentId = cityId ?? provinceId,
                    DepartmentName = city ?? province

                };
                data.Add(wsUser);
            }
            _context.User.AddRange(data);
            await _context.SaveChangesAsync();
            _box.AppendText($"完成，共插入{data.Count}条数据!");
        }

        /// <summary>
        /// 批量插入个人信息
        /// </summary>
        public async Task InsertPersonFileAsync(List<PersonFileDto> data)
        {
            var insertData = new List<PersonFile>();
            int insertNumber = 0;
            foreach (var person in data)
            {
                // 查询关联字段内容
                var provinceId = _context.WorkOrganization.Where(o => o.OuName.Equals(person.ProvinceName))
                    .Select(s => s.OuId)
                    .FirstOrDefault();
                var cityId = _context.WorkOrganization.Where(o => o.OuName.Equals(person.CityName))
                    .Select(o => o.OuId)
                    .FirstOrDefault();
                var orgId = _context.WorkOrganization.Where(o => o.OuName.Equals(person.OrgName))
                    .Select(o => o.OuId)
                    .FirstOrDefault();

                var personFile = _mapper.Map<PersonFile>(person);
                personFile.ProvinceId = provinceId;
                personFile.CityId = cityId;
                personFile.OrgId = orgId;
                personFile.InputUser = "批量导入";
                // 判断是否存在，存在则更新
                var exist = _context.PersonFile.Where(p => p.Phone == personFile.Phone && p.ContactRole == personFile.ContactRole)
                    .FirstOrDefault();
                if (exist != null)
                {
                    dispatcher.Invoke(() =>
                    {
                        _box.AppendText($"更新数据{exist.RealName}:{exist.Phone}\r\n");
                    });

                    _context.Entry(exist).CurrentValues.SetValues(person);
                    exist.ProvinceId = provinceId;
                    exist.CityId = cityId;
                    exist.OrgId = orgId;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    dispatcher.Invoke(() =>
                    {
                        _box.AppendText($"[{insertNumber}]添加数据{personFile.Phone}\r\n");
                    });
                    insertNumber++;
                    _context.Add(personFile);
                    await _context.SaveChangesAsync();
                }
            }
            dispatcher.Invoke(() =>
            {
                _box.AppendText($"完成，共插入{insertNumber}条数据!\r\n");
            });
        }


        /// <summary>
        /// 批量插入组织信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task InsertOrgInfoAsync(List<OrgInfoDto> data)
        {
            var insertData = new List<OrganizationInfo>();
            foreach (var orgInfo in data)
            {
                // 根据单位名称
                var org = _context.WorkOrganization.Where(o => o.OuName.Equals(orgInfo.OrgName))
                    .FirstOrDefault();
                if (org == null)
                {
                    org = _context.WorkOrganization.Where(o => o.OuName.Equals(orgInfo.OrgName + "分公司"))
                    .FirstOrDefault();
                }

                var organizationInfo = _mapper.Map<OrganizationInfo>(orgInfo);
                organizationInfo.ProvinceId = org?.ProvinceId;
                organizationInfo.CityId = org?.CityId;
                organizationInfo.OrgId = org?.OuId;
                organizationInfo.DepartmentId = org?.OuId;
                insertData.Add(organizationInfo);
            }
            _context.OrganizationInfo.AddRange(insertData);
            await _context.SaveChangesAsync();
            _box.AppendText($"完成，共插入{insertData.Count}条数据!");
        }
        public async Task Test()
        {
            _context.LogMonthReportReview.Add(new LogMonthReportReview()
            {
                Content = "123",
                RealName = "22",
                ReportId = 1,
                Result = 2,

            });
            await _context.SaveChangesAsync();
        }
    }
}
