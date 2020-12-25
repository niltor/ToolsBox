using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataHelper.Entity.WSEntities
{
    public partial class work_safety3Context : DbContext
    {
        public work_safety3Context()
        {
        }

        public work_safety3Context(DbContextOptions<work_safety3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<ExportSetting> ExportSetting { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Flow> Flow { get; set; }
        public virtual DbSet<FlowAudit> FlowAudit { get; set; }
        public virtual DbSet<FlowAuditUser> FlowAuditUser { get; set; }
        public virtual DbSet<FlowLog> FlowLog { get; set; }
        public virtual DbSet<FlowLogAll> FlowLogAll { get; set; }
        public virtual DbSet<FormElemType> FormElemType { get; set; }
        public virtual DbSet<FormElemValue> FormElemValue { get; set; }
        public virtual DbSet<LogMonthReportReview> LogMonthReportReview { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<OrganizationInfo> OrganizationInfo { get; set; }
        public virtual DbSet<OuRel> OuRel { get; set; }
        public virtual DbSet<PersonFile> PersonFile { get; set; }
        public virtual DbSet<QuarterSetting> QuarterSetting { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<SafeCheckLogs> SafeCheckLogs { get; set; }
        public virtual DbSet<SafeDate> SafeDate { get; set; }
        public virtual DbSet<SafeDateConfig> SafeDateConfig { get; set; }
        public virtual DbSet<SafeErrorLogs> SafeErrorLogs { get; set; }
        public virtual DbSet<SafeFireAccident> SafeFireAccident { get; set; }
        public virtual DbSet<SafePersonal> SafePersonal { get; set; }
        public virtual DbSet<SafePersonalcount> SafePersonalcount { get; set; }
        public virtual DbSet<SafeProduct> SafeProduct { get; set; }
        public virtual DbSet<SafeProductAccident> SafeProductAccident { get; set; }
        public virtual DbSet<SafeProductAccidentImages> SafeProductAccidentImages { get; set; }
        public virtual DbSet<SafeProductOnsite> SafeProductOnsite { get; set; }
        public virtual DbSet<SafeProductcount> SafeProductcount { get; set; }
        public virtual DbSet<SafeQuestion> SafeQuestion { get; set; }
        public virtual DbSet<SafeQuestioncount> SafeQuestioncount { get; set; }
        public virtual DbSet<SafeRel> SafeRel { get; set; }
        public virtual DbSet<TableList> TableList { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMenu> UserMenu { get; set; }
        public virtual DbSet<WoAudit> WoAudit { get; set; }
        public virtual DbSet<WoAuditRes> WoAuditRes { get; set; }
        public virtual DbSet<WorkOrganization> WorkOrganization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=work_safety3");
                optionsBuilder.UseMySQL("server=110.56.18.141;port=3306;user=root;password=cmttIP@2019;database=work_safety3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("nation国家province省city地市distrinct");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("行政代码");

                entity.Property(e => e.OuName)
                    .HasColumnName("ou_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("区域名称");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)")
                    .HasComment("父级行政区域ID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ExportSetting>(entity =>
            {
                entity.ToTable("export_setting");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataRow)
                    .HasColumnName("data_row")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndRow)
                    .HasColumnName("end_row")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.StartRow)
                    .HasColumnName("start_row")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tab)
                    .HasColumnName("tab")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TabId)
                    .HasColumnName("tab_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnName("create_time");

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("文件后缀");

                entity.Property(e => e.Mokuai)
                    .HasColumnName("mokuai")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("模块名称");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("文件名称");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasComment("文件路径");
            });

            modelBuilder.Entity<Flow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("flow");

                entity.HasComment("流程表");

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)")
                    .HasComment("流程ID");

                entity.Property(e => e.FlowName)
                    .HasColumnName("flow_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("流程名称");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)")
                    .HasComment("1地市  2 省份  3 总部");

                entity.Property(e => e.Mount)
                    .HasColumnName("mount")
                    .HasColumnType("int(11)")
                    .HasComment("一共几个步骤");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)")
                    .HasComment("角色ID");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(11)")
                    .HasComment("审核步骤顺序");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowAudit>(entity =>
            {
                entity.ToTable("flow_audit");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("流程名称");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("int(11)")
                    .HasComment("角色id");

                entity.Property(e => e.RoleLevel)
                    .HasColumnName("roleLevel")
                    .HasColumnType("int(2)");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(2)")
                    .HasComment("步数");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("流程类型");
            });

            modelBuilder.Entity<FlowAuditUser>(entity =>
            {
                entity.ToTable("flow_audit_user");

                entity.HasIndex(e => e.ReportId)
                    .HasName("indexReportId");

                entity.HasIndex(e => e.Step)
                    .HasName("indexStep");

                entity.HasIndex(e => e.Type)
                    .HasName("indexType");

                entity.HasIndex(e => e.UserId)
                    .HasName("indexUserId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActionType)
                    .HasColumnName("actionType")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("操作类型 0新增;1修改;-1删除");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasComment("内容");

                entity.Property(e => e.ContentTime)
                    .HasColumnName("contentTime")
                    .HasComment("最新时间");

                entity.Property(e => e.IsValid)
                    .HasColumnName("isValid")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReportId)
                    .HasColumnName("reportId")
                    .HasColumnType("int(11)")
                    .HasComment("关联id");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("int(11)")
                    .HasComment("角色id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("角色名");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasComment("0:待审;1通过;-1未通过");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(2)")
                    .HasComment("步骤");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("类型");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasComment("用户id");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("用户名");
            });

            modelBuilder.Entity<FlowLog>(entity =>
            {
                entity.ToTable("flow_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckResult)
                    .HasColumnName("check_result")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnName("create_time");

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OptTime).HasColumnName("opt_time");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TableId)
                    .HasColumnName("table_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowLogAll>(entity =>
            {
                entity.ToTable("flow_log_all");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckResult)
                    .HasColumnName("check_result")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OptTime).HasColumnName("opt_time");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TableId)
                    .HasColumnName("table_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormElemType>(entity =>
            {
                entity.ToTable("form_elem_type");

                entity.HasComment("表单元素类型");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hide)
                    .HasColumnName("hide")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Jingdu)
                    .HasColumnName("jingdu")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("类型");
            });

            modelBuilder.Entity<FormElemValue>(entity =>
            {
                entity.ToTable("form_elem_value");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("类型");
            });

            modelBuilder.Entity<LogMonthReportReview>(entity =>
            {
                entity.ToTable("log_month_report_review");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("indexTime");

                entity.HasIndex(e => e.ReportId)
                    .HasName("indexReport");

                entity.HasIndex(e => e.Result)
                    .HasName("indexResult");

                entity.HasIndex(e => e.Type)
                    .HasName("indexType");

                entity.HasIndex(e => e.UserId)
                    .HasName("indexUser");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActionType)
                    .HasColumnName("actionType")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("审核类型 0 新增;1 修改;-1 删除");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("审核内容");

                entity.Property(e => e.CreatedTime).HasColumnName("createdTime");

                entity.Property(e => e.RealName)
                    .HasColumnName("realName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("审核人名称");

                entity.Property(e => e.ReportId)
                    .HasColumnName("reportId")
                    .HasColumnType("int(11)")
                    .HasComment("关联的报表id");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("int(1)")
                    .HasComment("审核结果");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("报表类型");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1启用0停用");

                entity.Property(e => e.Hide)
                    .HasColumnName("hide")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0显示1隐藏");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("图标");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("菜单名称");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("父级菜单");

                entity.Property(e => e.Pids)
                    .HasColumnName("pids")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("父级");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("解释");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("1、url 2、菜单");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("访问地址");
            });

            modelBuilder.Entity<OrganizationInfo>(entity =>
            {
                entity.ToTable("organization_info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("联系人");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contactEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId)
                    .HasColumnName("contactId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactInnerPhone)
                    .HasColumnName("contactInnerPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contactPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPublicPhone)
                    .HasColumnName("contactPublicPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactStatus)
                    .HasColumnName("contactStatus")
                    .HasColumnType("int(1)");

                entity.Property(e => e.FullTimeNumber)
                    .HasColumnName("fullTimeNumber")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("全职数量");

                entity.Property(e => e.Leader)
                    .HasColumnName("leader")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("公司分管领导");

                entity.Property(e => e.LeaderEmail)
                    .HasColumnName("leaderEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderId)
                    .HasColumnName("leaderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LeaderInnerPhone)
                    .HasColumnName("leaderInnerPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderPhone)
                    .HasColumnName("leaderPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderPublicPhone)
                    .HasColumnName("leaderPublicPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderStatus)
                    .HasColumnName("leaderStatus")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(1)")
                    .HasComment("层级总0省1市2区3");

                entity.Property(e => e.MainFullTimeNumber)
                    .HasColumnName("mainFullTimeNumber")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("主管部门全职数量");

                entity.Property(e => e.MainPartTimeNumber)
                    .HasColumnName("mainPartTimeNumber")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("主管部门兼职数量");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("主管部门名称");

                entity.Property(e => e.OrgId)
                    .HasColumnName("orgId")
                    .HasColumnType("int(11)")
                    .HasComment("组织结构id");

                entity.Property(e => e.OrgName)
                    .HasColumnName("orgName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartTimeNumber)
                    .HasColumnName("partTimeNumber")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("兼职数量");

                entity.Property(e => e.Principal)
                    .HasColumnName("principal")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("安监机构 负责人");

                entity.Property(e => e.PrincipalEmail)
                    .HasColumnName("principalEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalId)
                    .HasColumnName("principalId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrincipalInnerPhone)
                    .HasColumnName("principalInnerPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLeader)
                    .HasColumnName("principalLeader")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("部门分管领导");

                entity.Property(e => e.PrincipalLeaderEmail)
                    .HasColumnName("principalLeaderEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLeaderId)
                    .HasColumnName("principalLeaderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrincipalLeaderInnerPhone)
                    .HasColumnName("principalLeaderInnerPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLeaderPhone)
                    .HasColumnName("principalLeaderPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLeaderPublicPhone)
                    .HasColumnName("principalLeaderPublicPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalLeaderStatus)
                    .HasColumnName("principalLeaderStatus")
                    .HasColumnType("int(1)");

                entity.Property(e => e.PrincipalPhone)
                    .HasColumnName("principalPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalPublicPhone)
                    .HasColumnName("principalPublicPhone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalStatus)
                    .HasColumnName("principalStatus")
                    .HasColumnType("int(1)");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalNumber)
                    .HasColumnName("totalNumber")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<OuRel>(entity =>
            {
                entity.ToTable("ou_rel");

                entity.HasComment("组织机构映射表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AreaId)
                    .HasColumnName("area_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InName)
                    .HasColumnName("in_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("内部名称");

                entity.Property(e => e.OuId)
                    .HasColumnName("ou_id")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构ID");

                entity.Property(e => e.OuName)
                    .HasColumnName("ou_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("组织机构名称");

                entity.Property(e => e.OutName)
                    .HasColumnName("out_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("外部名称、移动名称");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PersonFile>(entity =>
            {
                entity.ToTable("person_file");

                entity.HasComment("人事档案");

                entity.HasIndex(e => e.CityId)
                    .HasName("index_cityId");

                entity.HasIndex(e => e.Email)
                    .HasName("index_email");

                entity.HasIndex(e => e.OrgId)
                    .HasName("index_orgId");

                entity.HasIndex(e => e.Phone)
                    .HasName("index_phone")
                    .IsUnique();

                entity.HasIndex(e => e.RealName)
                    .HasName("index_name");

                entity.HasIndex(e => new { e.IsFulltime, e.IsPartTime, e.RegSafetyEngineer, e.RegFireEngineer })
                    .HasName("index_filter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActionType)
                    .HasColumnName("actionType")
                    .HasColumnType("tinyint(1)")
                    .HasComment("当前操作 0新增;1修改;-1删除");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityId")
                    .HasColumnType("int(11)")
                    .HasComment("地市级公司");

                entity.Property(e => e.CityName)
                    .HasColumnName("cityName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("createdTime")
                    .HasComment("创建时间");

                entity.Property(e => e.DeletedTime).HasColumnName("deletedTime");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("学历");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InputUser)
                    .HasColumnName("inputUser")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InputUserId)
                    .HasColumnName("inputUserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InputUserLevel)
                    .HasColumnName("inputUserLevel")
                    .HasColumnType("int(2)");

                entity.Property(e => e.InternalPhone)
                    .HasColumnName("internalPhone")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("路电");

                entity.Property(e => e.ContactRole)
                    .HasColumnName("contactRole")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否为联系人");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否删除");

                entity.Property(e => e.IsFulltime)
                    .HasColumnName("isFulltime")
                    .HasColumnType("tinyint(1)")
                    .HasComment("是否全日制");

                entity.Property(e => e.IsLeader)
                    .HasColumnName("isLeader")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否为分管领导");

                entity.Property(e => e.IsOnJob)
                    .HasColumnName("isOnJob")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否在职");

                entity.Property(e => e.IsPartTime)
                    .HasColumnName("isPartTime")
                    .HasColumnType("tinyint(1)")
                    .HasComment("是否兼职");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("员工编号 11");

                entity.Property(e => e.OrgId)
                    .HasColumnName("orgId")
                    .HasColumnType("int(4)")
                    .HasComment("组织结构id");

                entity.Property(e => e.OrgName)
                    .HasColumnName("orgName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("手机");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("职务");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasColumnType("int(11)")
                    .HasComment("省级单位");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("provinceName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublicPhone)
                    .HasColumnName("publicPhone")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("市电");

                entity.Property(e => e.RealName)
                    .HasColumnName("realName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegFireEngineer)
                    .HasColumnName("regFireEngineer")
                    .HasColumnType("tinyint(1)")
                    .HasComment("是否注册消防工程师");

                entity.Property(e => e.RegSafetyEngineer)
                    .HasColumnName("regSafetyEngineer")
                    .HasColumnType("tinyint(1)")
                    .HasComment("是否注册安全工程师");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("状态 默认0,通过10，未通过-1，在审核1");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("在审核步骤");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updatedTime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<QuarterSetting>(entity =>
            {
                entity.ToTable("quarter_setting");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("ID");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("is_admin")
                    .HasColumnType("int(11)")
                    .HasComment("是否是管理员");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)")
                    .HasComment("角色级别");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("角色名称");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasComment("状态");
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.ToTable("role_menu");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenuIds)
                    .HasColumnName("menuIds")
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SafeCheckLogs>(entity =>
            {
                entity.ToTable("safe_check_logs");

                entity.HasComment("审核记录日志表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("1、add \\2 edit3\\delete4check");

                entity.Property(e => e.AddTime)
                    .HasColumnName("add_time")
                    .HasComment("审核时间");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("int(10) unsigned")
                    .HasComment("审核人id");

                entity.Property(e => e.Controller)
                    .HasColumnName("controller")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurStep)
                    .HasColumnName("cur_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsCount)
                    .HasColumnName("is_count")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecordId)
                    .HasColumnName("record_id")
                    .HasColumnType("int(10) unsigned")
                    .HasComment("审核记录id");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasComment("类型（1-安全生产 2-个人工作 3-安全隐患）");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SafeDate>(entity =>
            {
                entity.ToTable("safe_date");

                entity.HasComment("设置表单提交截止时间");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(11)")
                    .HasComment("季度");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TabId)
                    .HasColumnName("tab_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SafeDateConfig>(entity =>
            {
                entity.ToTable("safe_date_config");

                entity.HasComment("填报时间配置");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasComment("结束时间");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(2)")
                    .HasComment("月度");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("显示名");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(2)")
                    .HasComment("季度");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasComment("开始时间");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("类型");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("值");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(2)")
                    .HasComment("年份");
            });

            modelBuilder.Entity<SafeErrorLogs>(entity =>
            {
                entity.ToTable("safe_error_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasColumnName("controller")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnName("create_time");

                entity.Property(e => e.Filepath).HasColumnName("filepath");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SafeFireAccident>(entity =>
            {
                entity.ToTable("safe_fire_accident");

                entity.HasIndex(e => e.Number)
                    .HasName("indexNumber");

                entity.HasIndex(e => e.OrgId)
                    .HasName("indexOrg");

                entity.HasIndex(e => e.Time)
                    .HasName("indexTime");

                entity.HasIndex(e => new { e.Year, e.Month })
                    .HasName("indexMonth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Auditor)
                    .HasColumnName("auditor")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("审核人");

                entity.Property(e => e.AuditorId)
                    .HasColumnName("auditorId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BlockHours)
                    .HasColumnName("blockHours")
                    .HasColumnType("int(255)")
                    .HasComment("阻断时间");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("createdTime")
                    .HasComment("创建时间");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("详情及处理");

                entity.Property(e => e.EconomyLose)
                    .HasColumnName("economyLose")
                    .HasColumnType("float(15,0)")
                    .HasComment("经济损失");

                entity.Property(e => e.InputUser)
                    .HasColumnName("inputUser")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("填表人");

                entity.Property(e => e.InputUserId)
                    .HasColumnName("inputUserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InputUserLevel)
                    .HasColumnName("inputUserLevel")
                    .HasColumnType("int(2)");

                entity.Property(e => e.Leader)
                    .HasColumnName("leader")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(" 省分公司分管领导");

                entity.Property(e => e.LeaderId)
                    .HasColumnName("leaderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("等级");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("发生地");

                entity.Property(e => e.MainPrincipal)
                    .HasColumnName("mainPrincipal")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("省分公司主负责人");

                entity.Property(e => e.MainPrincipalId)
                    .HasColumnName("mainPrincipalId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(2)")
                    .HasComment("月份");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("编号 ");

                entity.Property(e => e.OrgId)
                    .HasColumnName("orgId")
                    .HasColumnType("int(11)")
                    .HasComment("填报单位");

                entity.Property(e => e.OrgName)
                    .HasColumnName("orgName")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("单位名称");

                entity.Property(e => e.Part)
                    .HasColumnName("part")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("发生部位");

                entity.Property(e => e.SelfDeathNumber)
                    .HasColumnName("selfDeathNumber")
                    .HasColumnType("int(9)")
                    .HasComment("本企业死亡人数");

                entity.Property(e => e.SelfHeavyInjuredNumber)
                    .HasColumnName("selfHeavyInjuredNumber")
                    .HasColumnType("int(9)")
                    .HasComment("本企业重伤");

                entity.Property(e => e.SelfInjuredNumber)
                    .HasColumnName("selfInjuredNumber")
                    .HasColumnType("int(9)")
                    .HasComment("本企业轻伤");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(255)")
                    .HasComment("状态");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(2)")
                    .HasComment("步骤");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasComment("时间");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updatedTime")
                    .HasComment("更新时间");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(4)")
                    .HasComment("年份");
            });

            modelBuilder.Entity<SafePersonal>(entity =>
            {
                entity.ToTable("safe_personal");

                entity.HasComment("安监机构每人季度工作量统计汇总表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateName)
                    .HasColumnName("create_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasComment("提交时间");

                entity.Property(e => e.CreateUid)
                    .HasColumnName("create_uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrentStep)
                    .HasColumnName("current_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构映射ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("province_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(11)")
                    .HasComment("季度");

                entity.Property(e => e.SpName1)
                    .HasColumnName("sp_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpName10)
                    .HasColumnName("sp_name10")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName11)
                    .HasColumnName("sp_name11")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName12)
                    .HasColumnName("sp_name12")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName13)
                    .HasColumnName("sp_name13")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName14)
                    .HasColumnName("sp_name14")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName15)
                    .HasColumnName("sp_name15")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName16)
                    .HasColumnName("sp_name16")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName17)
                    .HasColumnName("sp_name17")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName18)
                    .HasColumnName("sp_name18")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName19)
                    .HasColumnName("sp_name19")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName2)
                    .HasColumnName("sp_name2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpName20)
                    .HasColumnName("sp_name20")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName21)
                    .HasColumnName("sp_name21")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("备用1");

                entity.Property(e => e.SpName22)
                    .HasColumnName("sp_name22")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName23)
                    .HasColumnName("sp_name23")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName24)
                    .HasColumnName("sp_name24")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName25)
                    .HasColumnName("sp_name25")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName26)
                    .HasColumnName("sp_name26")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName27)
                    .HasColumnName("sp_name27")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName28)
                    .HasColumnName("sp_name28")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName29)
                    .HasColumnName("sp_name29")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName3)
                    .HasColumnName("sp_name3")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("室外现场检查天数（最小统计到0.5天）");

                entity.Property(e => e.SpName30)
                    .HasColumnName("sp_name30")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName31)
                    .HasColumnName("sp_name31")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName32)
                    .HasColumnName("sp_name32")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName33)
                    .HasColumnName("sp_name33")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName34)
                    .HasColumnName("sp_name34")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName35)
                    .HasColumnName("sp_name35")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName36)
                    .HasColumnName("sp_name36")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName37)
                    .HasColumnName("sp_name37")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName38)
                    .HasColumnName("sp_name38")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName39)
                    .HasColumnName("sp_name39")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName4)
                    .HasColumnName("sp_name4")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("是否按公司要求组织自查、复查工作");

                entity.Property(e => e.SpName40)
                    .HasColumnName("sp_name40")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName41)
                    .HasColumnName("sp_name41")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName42)
                    .HasColumnName("sp_name42")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName43)
                    .HasColumnName("sp_name43")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName44)
                    .HasColumnName("sp_name44")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName45)
                    .HasColumnName("sp_name45")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName46)
                    .HasColumnName("sp_name46")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName47)
                    .HasColumnName("sp_name47")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName48)
                    .HasColumnName("sp_name48")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName49)
                    .HasColumnName("sp_name49")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName5)
                    .HasColumnName("sp_name5")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName50)
                    .HasColumnName("sp_name50")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName51)
                    .HasColumnName("sp_name51")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName52)
                    .HasColumnName("sp_name52")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName53)
                    .HasColumnName("sp_name53")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName54)
                    .HasColumnName("sp_name54")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName55)
                    .HasColumnName("sp_name55")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName56)
                    .HasColumnName("sp_name56")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName57)
                    .HasColumnName("sp_name57")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName58)
                    .HasColumnName("sp_name58")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName59)
                    .HasColumnName("sp_name59")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName6)
                    .HasColumnName("sp_name6")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName60)
                    .HasColumnName("sp_name60")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName61)
                    .HasColumnName("sp_name61")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName62)
                    .HasColumnName("sp_name62")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName63)
                    .HasColumnName("sp_name63")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName64)
                    .HasColumnName("sp_name64")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName65)
                    .HasColumnName("sp_name65")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName66)
                    .HasColumnName("sp_name66")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName7)
                    .HasColumnName("sp_name7")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName8)
                    .HasColumnName("sp_name8")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName9)
                    .HasColumnName("sp_name9")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasComment("安全员id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("用户名");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("季度的年");
            });

            modelBuilder.Entity<SafePersonalcount>(entity =>
            {
                entity.ToTable("safe_personalcount");

                entity.HasComment("安监机构每人季度工作量统计汇总表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Checkcount)
                    .HasColumnName("checkcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasComment("提交时间");

                entity.Property(e => e.CurrentStep)
                    .HasColumnName("current_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构映射ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(11)")
                    .HasComment("季度");

                entity.Property(e => e.SpName1)
                    .HasColumnName("sp_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpName10)
                    .HasColumnName("sp_name10")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName11)
                    .HasColumnName("sp_name11")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName12)
                    .HasColumnName("sp_name12")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName13)
                    .HasColumnName("sp_name13")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName14)
                    .HasColumnName("sp_name14")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName15)
                    .HasColumnName("sp_name15")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName16)
                    .HasColumnName("sp_name16")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName17)
                    .HasColumnName("sp_name17")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName18)
                    .HasColumnName("sp_name18")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName19)
                    .HasColumnName("sp_name19")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName2)
                    .HasColumnName("sp_name2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpName20)
                    .HasColumnName("sp_name20")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName21)
                    .HasColumnName("sp_name21")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("备用1");

                entity.Property(e => e.SpName22)
                    .HasColumnName("sp_name22")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName23)
                    .HasColumnName("sp_name23")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName24)
                    .HasColumnName("sp_name24")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName25)
                    .HasColumnName("sp_name25")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName26)
                    .HasColumnName("sp_name26")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName27)
                    .HasColumnName("sp_name27")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName28)
                    .HasColumnName("sp_name28")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName29)
                    .HasColumnName("sp_name29")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName3)
                    .HasColumnName("sp_name3")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("室外现场检查天数（最小统计到0.5天）");

                entity.Property(e => e.SpName30)
                    .HasColumnName("sp_name30")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName31)
                    .HasColumnName("sp_name31")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName32)
                    .HasColumnName("sp_name32")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName33)
                    .HasColumnName("sp_name33")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName34)
                    .HasColumnName("sp_name34")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName35)
                    .HasColumnName("sp_name35")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName36)
                    .HasColumnName("sp_name36")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName37)
                    .HasColumnName("sp_name37")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName38)
                    .HasColumnName("sp_name38")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName39)
                    .HasColumnName("sp_name39")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName4)
                    .HasColumnName("sp_name4")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("是否按公司要求组织自查、复查工作");

                entity.Property(e => e.SpName40)
                    .HasColumnName("sp_name40")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName41)
                    .HasColumnName("sp_name41")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName42)
                    .HasColumnName("sp_name42")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName43)
                    .HasColumnName("sp_name43")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName44)
                    .HasColumnName("sp_name44")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName45)
                    .HasColumnName("sp_name45")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName46)
                    .HasColumnName("sp_name46")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName47)
                    .HasColumnName("sp_name47")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName48)
                    .HasColumnName("sp_name48")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName49)
                    .HasColumnName("sp_name49")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName5)
                    .HasColumnName("sp_name5")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName50)
                    .HasColumnName("sp_name50")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName51)
                    .HasColumnName("sp_name51")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName52)
                    .HasColumnName("sp_name52")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName53)
                    .HasColumnName("sp_name53")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName54)
                    .HasColumnName("sp_name54")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName55)
                    .HasColumnName("sp_name55")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName56)
                    .HasColumnName("sp_name56")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName57)
                    .HasColumnName("sp_name57")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName58)
                    .HasColumnName("sp_name58")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName59)
                    .HasColumnName("sp_name59")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName6)
                    .HasColumnName("sp_name6")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName60)
                    .HasColumnName("sp_name60")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName61)
                    .HasColumnName("sp_name61")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName62)
                    .HasColumnName("sp_name62")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName63)
                    .HasColumnName("sp_name63")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName64)
                    .HasColumnName("sp_name64")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName65)
                    .HasColumnName("sp_name65")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName66)
                    .HasColumnName("sp_name66")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName7)
                    .HasColumnName("sp_name7")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName8)
                    .HasColumnName("sp_name8")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpName9)
                    .HasColumnName("sp_name9")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Submitcount)
                    .HasColumnName("submitcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Totalcount)
                    .HasColumnName("totalcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasComment("安全员id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("用户名");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("季度的年");
            });

            modelBuilder.Entity<SafeProduct>(entity =>
            {
                entity.ToTable("safe_product");

                entity.HasComment("安全生产工作开展情况上报");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateName)
                    .HasColumnName("create_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasComment("提交时间");

                entity.Property(e => e.CreateUid)
                    .HasColumnName("create_uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrentStep)
                    .HasColumnName("current_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构映射id");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsCount)
                    .HasColumnName("is_count")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否是 汇总表0是否");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("province_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(1)")
                    .HasComment("季度");

                entity.Property(e => e.SfName1)
                    .HasColumnName("sf_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName10)
                    .HasColumnName("sf_name10")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName100)
                    .HasColumnName("sf_name100")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName11)
                    .HasColumnName("sf_name11")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName12)
                    .HasColumnName("sf_name12")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName13)
                    .HasColumnName("sf_name13")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName14)
                    .HasColumnName("sf_name14")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName15)
                    .HasColumnName("sf_name15")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName16)
                    .HasColumnName("sf_name16")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName17)
                    .HasColumnName("sf_name17")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName18)
                    .HasColumnName("sf_name18")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName19)
                    .HasColumnName("sf_name19")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName2)
                    .HasColumnName("sf_name2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName20)
                    .HasColumnName("sf_name20")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName21)
                    .HasColumnName("sf_name21")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName22)
                    .HasColumnName("sf_name22")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName23)
                    .HasColumnName("sf_name23")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName24)
                    .HasColumnName("sf_name24")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName25)
                    .HasColumnName("sf_name25")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName26)
                    .HasColumnName("sf_name26")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName27)
                    .HasColumnName("sf_name27")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName28)
                    .HasColumnName("sf_name28")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName29)
                    .HasColumnName("sf_name29")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName3)
                    .HasColumnName("sf_name3")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName30)
                    .HasColumnName("sf_name30")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName31)
                    .HasColumnName("sf_name31")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName32)
                    .HasColumnName("sf_name32")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName33)
                    .HasColumnName("sf_name33")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName34)
                    .HasColumnName("sf_name34")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName35)
                    .HasColumnName("sf_name35")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName36)
                    .HasColumnName("sf_name36")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName37)
                    .HasColumnName("sf_name37")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName38)
                    .HasColumnName("sf_name38")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName39)
                    .HasColumnName("sf_name39")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName4)
                    .HasColumnName("sf_name4")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName40)
                    .HasColumnName("sf_name40")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName41)
                    .HasColumnName("sf_name41")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName42)
                    .HasColumnName("sf_name42")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName43)
                    .HasColumnName("sf_name43")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName44)
                    .HasColumnName("sf_name44")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName45)
                    .HasColumnName("sf_name45")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SfName46)
                    .HasColumnName("sf_name46")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName47)
                    .HasColumnName("sf_name47")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName48)
                    .HasColumnName("sf_name48")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName49)
                    .HasColumnName("sf_name49")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName5)
                    .HasColumnName("sf_name5")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName50)
                    .HasColumnName("sf_name50")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName51)
                    .HasColumnName("sf_name51")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName52)
                    .HasColumnName("sf_name52")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName53)
                    .HasColumnName("sf_name53")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName54)
                    .HasColumnName("sf_name54")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName55)
                    .HasColumnName("sf_name55")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName56)
                    .HasColumnName("sf_name56")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName57)
                    .HasColumnName("sf_name57")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName58)
                    .HasColumnName("sf_name58")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName59)
                    .HasColumnName("sf_name59")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName6)
                    .HasColumnName("sf_name6")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName60)
                    .HasColumnName("sf_name60")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName61)
                    .HasColumnName("sf_name61")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName62)
                    .HasColumnName("sf_name62")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName63)
                    .HasColumnName("sf_name63")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName64)
                    .HasColumnName("sf_name64")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName65)
                    .HasColumnName("sf_name65")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName66)
                    .HasColumnName("sf_name66")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName67)
                    .HasColumnName("sf_name67")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName68)
                    .HasColumnName("sf_name68")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName69)
                    .HasColumnName("sf_name69")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName7)
                    .HasColumnName("sf_name7")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName70)
                    .HasColumnName("sf_name70")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName71)
                    .HasColumnName("sf_name71")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName72)
                    .HasColumnName("sf_name72")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName73)
                    .HasColumnName("sf_name73")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName74)
                    .HasColumnName("sf_name74")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName75)
                    .HasColumnName("sf_name75")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName76)
                    .HasColumnName("sf_name76")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName77)
                    .HasColumnName("sf_name77")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName78)
                    .HasColumnName("sf_name78")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName79)
                    .HasColumnName("sf_name79")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName8)
                    .HasColumnName("sf_name8")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName80)
                    .HasColumnName("sf_name80")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName81)
                    .HasColumnName("sf_name81")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName82)
                    .HasColumnName("sf_name82")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName83)
                    .HasColumnName("sf_name83")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName84)
                    .HasColumnName("sf_name84")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName85)
                    .HasColumnName("sf_name85")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName86)
                    .HasColumnName("sf_name86")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName87)
                    .HasColumnName("sf_name87")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName88)
                    .HasColumnName("sf_name88")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName89)
                    .HasColumnName("sf_name89")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName9)
                    .HasColumnName("sf_name9")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName90)
                    .HasColumnName("sf_name90")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName91)
                    .HasColumnName("sf_name91")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName92)
                    .HasColumnName("sf_name92")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName93)
                    .HasColumnName("sf_name93")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName94)
                    .HasColumnName("sf_name94")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName95)
                    .HasColumnName("sf_name95")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName96)
                    .HasColumnName("sf_name96")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName97)
                    .HasColumnName("sf_name97")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName98)
                    .HasColumnName("sf_name98")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName99)
                    .HasColumnName("sf_name99")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasComment("0 未审核 1 已审核 2 驳回 3 审核中");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("年");
            });

            modelBuilder.Entity<SafeProductAccident>(entity =>
            {
                entity.ToTable("safe_product_accident");

                entity.HasComment("生产安全事故报告表");

                entity.HasIndex(e => e.Number)
                    .HasName("indexNumber");

                entity.HasIndex(e => e.OrgId)
                    .HasName("indexOrg");

                entity.HasIndex(e => e.Time)
                    .HasName("indexTime");

                entity.HasIndex(e => new { e.Year, e.Month })
                    .HasName("indexMonth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Auditor)
                    .HasColumnName("auditor")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("审核人");

                entity.Property(e => e.AuditorId)
                    .HasColumnName("auditorId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BlockHours)
                    .HasColumnName("blockHours")
                    .HasColumnType("int(255)")
                    .HasComment("阻断时间");

                entity.Property(e => e.Classification)
                    .HasColumnName("classification")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("分类");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("createdTime")
                    .HasComment("创建时间");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("详情及处理");

                entity.Property(e => e.DutyClassification)
                    .HasColumnName("dutyClassification")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("责任分类");

                entity.Property(e => e.EconomyLose)
                    .HasColumnName("economyLose")
                    .HasColumnType("float(15,0)")
                    .HasComment("经济损失");

                entity.Property(e => e.InputUser)
                    .HasColumnName("inputUser")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("填表人");

                entity.Property(e => e.InputUserId)
                    .HasColumnName("inputUserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InputUserLevel)
                    .HasColumnName("inputUserLevel")
                    .HasColumnType("int(11)")
                    .HasComment("填表人role等级");

                entity.Property(e => e.Leader)
                    .HasColumnName("leader")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(" 省分公司分管领导");

                entity.Property(e => e.LeaderId)
                    .HasColumnName("leaderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("等级");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("发生地");

                entity.Property(e => e.MainPrincipal)
                    .HasColumnName("mainPrincipal")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("省分公司主负责人");

                entity.Property(e => e.MainPrincipalId)
                    .HasColumnName("mainPrincipalId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(2)")
                    .HasComment("月份");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("编号 ");

                entity.Property(e => e.OrgId)
                    .HasColumnName("orgId")
                    .HasColumnType("int(11)")
                    .HasComment("填报单位");

                entity.Property(e => e.OrgName)
                    .HasColumnName("orgName")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("单位名称");

                entity.Property(e => e.OtherDeathNumber)
                    .HasColumnName("otherDeathNumber")
                    .HasColumnType("int(9)")
                    .HasComment("外单位死亡人数");

                entity.Property(e => e.OtherHeavyInjuredNumber)
                    .HasColumnName("otherHeavyInjuredNumber")
                    .HasColumnType("int(9)")
                    .HasComment("外单位重伤");

                entity.Property(e => e.OtherInjuredNumber)
                    .HasColumnName("otherInjuredNumber")
                    .HasColumnType("int(9)")
                    .HasComment("外单位轻伤");

                entity.Property(e => e.SelfDeathNumber)
                    .HasColumnName("selfDeathNumber")
                    .HasColumnType("int(9)")
                    .HasComment("本企业死亡人数");

                entity.Property(e => e.SelfHeavyInjuredNumber)
                    .HasColumnName("selfHeavyInjuredNumber")
                    .HasColumnType("int(9)")
                    .HasComment("本企业重伤");

                entity.Property(e => e.SelfInjuredNumber)
                    .HasColumnName("selfInjuredNumber")
                    .HasColumnType("int(9)")
                    .HasComment("本企业轻伤");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(255)")
                    .HasComment("状态");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(2)")
                    .HasComment("步驟");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasComment("时间");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updatedTime")
                    .HasComment("更新时间");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(4)")
                    .HasComment("年份");
            });

            modelBuilder.Entity<SafeProductAccidentImages>(entity =>
            {
                entity.ToTable("safe_product_accident_images");

                entity.HasComment("安全事故上传的图片资源");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SafeProductOnsite>(entity =>
            {
                entity.ToTable("safe_product_onsite");

                entity.HasComment("省公司领导赴一线现场安全生产检查汇总表");

                entity.HasIndex(e => e.CheckDate)
                    .HasName("indexDate");

                entity.HasIndex(e => e.HasIssue)
                    .HasName("indexIssue");

                entity.HasIndex(e => e.IssueType)
                    .HasName("indexIssueType");

                entity.HasIndex(e => e.OrgId)
                    .HasName("indexOrgId");

                entity.HasIndex(e => new { e.Year, e.Month })
                    .HasName("indexYear");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckContent)
                    .HasColumnName("checkContent")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment(" 检查内容");

                entity.Property(e => e.CheckDate)
                    .HasColumnName("checkDate")
                    .HasColumnType("date")
                    .HasComment("检查日期");

                entity.Property(e => e.CheckForm)
                    .HasColumnName("checkForm")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment(" 检查形式");

                entity.Property(e => e.CityOrgId)
                    .HasColumnName("cityOrgId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityOrgName)
                    .HasColumnName("cityOrgName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment(" 地市分公司");

                entity.Property(e => e.ClassGroup)
                    .HasColumnName("classGroup")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("班组");

                entity.Property(e => e.CreatedTime).HasColumnName("createdTime");

                entity.Property(e => e.HasIssue)
                    .HasColumnName("hasIssue")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否有问题,默认0没有,1 有");

                entity.Property(e => e.InputUser)
                    .HasColumnName("inputUser")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InputUserId)
                    .HasColumnName("inputUserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InputUserLevel)
                    .HasColumnName("inputUserLevel")
                    .HasColumnType("int(2)");

                entity.Property(e => e.Issue)
                    .HasColumnName("issue")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment(" 问题");

                entity.Property(e => e.IssueNumber)
                    .HasColumnName("issueNumber")
                    .HasColumnType("int(2)")
                    .HasComment("问题总数");

                entity.Property(e => e.IssueType)
                    .HasColumnName("issueType")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("问题分类");

                entity.Property(e => e.Leader)
                    .HasColumnName("leader")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderId)
                    .HasColumnName("leaderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Leaders)
                    .HasColumnName("leaders")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("参检领导");

                entity.Property(e => e.MainPrincipal)
                    .HasColumnName("mainPrincipal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MainPrincipalId)
                    .HasColumnName("mainPrincipalId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(2)");

                entity.Property(e => e.NoSolveNumber)
                    .HasColumnName("noSolveNumber")
                    .HasColumnType("int(11)")
                    .HasComment("未解决数量");

                entity.Property(e => e.OrgId)
                    .HasColumnName("orgId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrgName)
                    .HasColumnName("orgName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment(" 单位");

                entity.Property(e => e.Rectify)
                    .HasColumnName("rectify")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0未(无需)整改，1已整改");

                entity.Property(e => e.SolveNumber)
                    .HasColumnName("solveNumber")
                    .HasColumnType("int(2)")
                    .HasComment("已解决数量 ");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Step)
                    .HasColumnName("step")
                    .HasColumnType("int(2)")
                    .HasComment("当前步骤");

                entity.Property(e => e.SupportPartment)
                    .HasColumnName("supportPartment")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("支撑中心/项目部");

                entity.Property(e => e.SupportPartmentId)
                    .HasColumnName("supportPartmentId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeLimit)
                    .HasColumnName("timeLimit")
                    .HasColumnType("date")
                    .HasComment("整改时限");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(4)");
            });

            modelBuilder.Entity<SafeProductcount>(entity =>
            {
                entity.ToTable("safe_productcount");

                entity.HasComment("安全生产工作开展情况上报汇总表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Checkcount)
                    .HasColumnName("checkcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("审核通过个数");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasComment("提交时间");

                entity.Property(e => e.CurrentStep)
                    .HasColumnName("current_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构映射id");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsCount)
                    .HasColumnName("is_count")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否是汇总表 1是");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否可见");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(1)")
                    .HasComment("季度");

                entity.Property(e => e.SfName1)
                    .HasColumnName("sf_name1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SfName10)
                    .HasColumnName("sf_name10")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName100)
                    .HasColumnName("sf_name100")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName11)
                    .HasColumnName("sf_name11")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName12)
                    .HasColumnName("sf_name12")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName13)
                    .HasColumnName("sf_name13")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName14)
                    .HasColumnName("sf_name14")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName15)
                    .HasColumnName("sf_name15")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName16)
                    .HasColumnName("sf_name16")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName17)
                    .HasColumnName("sf_name17")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName18)
                    .HasColumnName("sf_name18")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName19)
                    .HasColumnName("sf_name19")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName2)
                    .HasColumnName("sf_name2")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName20)
                    .HasColumnName("sf_name20")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName21)
                    .HasColumnName("sf_name21")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName22)
                    .HasColumnName("sf_name22")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName23)
                    .HasColumnName("sf_name23")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName24)
                    .HasColumnName("sf_name24")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName25)
                    .HasColumnName("sf_name25")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName26)
                    .HasColumnName("sf_name26")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName27)
                    .HasColumnName("sf_name27")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName28)
                    .HasColumnName("sf_name28")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName29)
                    .HasColumnName("sf_name29")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName3)
                    .HasColumnName("sf_name3")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName30)
                    .HasColumnName("sf_name30")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName31)
                    .HasColumnName("sf_name31")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName32)
                    .HasColumnName("sf_name32")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName33)
                    .HasColumnName("sf_name33")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName34)
                    .HasColumnName("sf_name34")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName35)
                    .HasColumnName("sf_name35")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName36)
                    .HasColumnName("sf_name36")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName37)
                    .HasColumnName("sf_name37")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName38)
                    .HasColumnName("sf_name38")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName39)
                    .HasColumnName("sf_name39")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName4)
                    .HasColumnName("sf_name4")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName40)
                    .HasColumnName("sf_name40")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName41)
                    .HasColumnName("sf_name41")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName42)
                    .HasColumnName("sf_name42")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName43)
                    .HasColumnName("sf_name43")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName44)
                    .HasColumnName("sf_name44")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName45)
                    .HasColumnName("sf_name45")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName46)
                    .HasColumnName("sf_name46")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName47)
                    .HasColumnName("sf_name47")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName48)
                    .HasColumnName("sf_name48")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName49)
                    .HasColumnName("sf_name49")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName5)
                    .HasColumnName("sf_name5")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName50)
                    .HasColumnName("sf_name50")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName51)
                    .HasColumnName("sf_name51")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName52)
                    .HasColumnName("sf_name52")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName53)
                    .HasColumnName("sf_name53")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName54)
                    .HasColumnName("sf_name54")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName55)
                    .HasColumnName("sf_name55")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName56)
                    .HasColumnName("sf_name56")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName57)
                    .HasColumnName("sf_name57")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName58)
                    .HasColumnName("sf_name58")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName59)
                    .HasColumnName("sf_name59")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName6)
                    .HasColumnName("sf_name6")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName60)
                    .HasColumnName("sf_name60")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName61)
                    .HasColumnName("sf_name61")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName62)
                    .HasColumnName("sf_name62")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName63)
                    .HasColumnName("sf_name63")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName64)
                    .HasColumnName("sf_name64")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName65)
                    .HasColumnName("sf_name65")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName66)
                    .HasColumnName("sf_name66")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName67)
                    .HasColumnName("sf_name67")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName68)
                    .HasColumnName("sf_name68")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName69)
                    .HasColumnName("sf_name69")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName7)
                    .HasColumnName("sf_name7")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName70)
                    .HasColumnName("sf_name70")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName71)
                    .HasColumnName("sf_name71")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName72)
                    .HasColumnName("sf_name72")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName73)
                    .HasColumnName("sf_name73")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName74)
                    .HasColumnName("sf_name74")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName75)
                    .HasColumnName("sf_name75")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName76)
                    .HasColumnName("sf_name76")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName77)
                    .HasColumnName("sf_name77")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName78)
                    .HasColumnName("sf_name78")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName79)
                    .HasColumnName("sf_name79")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName8)
                    .HasColumnName("sf_name8")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName80)
                    .HasColumnName("sf_name80")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName81)
                    .HasColumnName("sf_name81")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName82)
                    .HasColumnName("sf_name82")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName83)
                    .HasColumnName("sf_name83")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName84)
                    .HasColumnName("sf_name84")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName85)
                    .HasColumnName("sf_name85")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName86)
                    .HasColumnName("sf_name86")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName87)
                    .HasColumnName("sf_name87")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName88)
                    .HasColumnName("sf_name88")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName89)
                    .HasColumnName("sf_name89")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName9)
                    .HasColumnName("sf_name9")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SfName90)
                    .HasColumnName("sf_name90")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName91)
                    .HasColumnName("sf_name91")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName92)
                    .HasColumnName("sf_name92")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName93)
                    .HasColumnName("sf_name93")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName94)
                    .HasColumnName("sf_name94")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName95)
                    .HasColumnName("sf_name95")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName96)
                    .HasColumnName("sf_name96")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName97)
                    .HasColumnName("sf_name97")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName98)
                    .HasColumnName("sf_name98")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SfName99)
                    .HasColumnName("sf_name99")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Submitcount)
                    .HasColumnName("submitcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("提交地市个数");

                entity.Property(e => e.Totalcount)
                    .HasColumnName("totalcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("应该审核通过的个数");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("年");
            });

            modelBuilder.Entity<SafeQuestion>(entity =>
            {
                entity.ToTable("safe_question");

                entity.HasComment("安监人员季度安全生产检查发现的问题和隐患数量汇总统计表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateName)
                    .HasColumnName("create_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasComment("提交时间");

                entity.Property(e => e.CreateUid)
                    .HasColumnName("create_uid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrentStep)
                    .HasColumnName("current_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构映射ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsCheck)
                    .HasColumnName("is_check")
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否审核  0未审核  1已审核");

                entity.Property(e => e.IsCount)
                    .HasColumnName("is_count")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否是汇总表 0 不是");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("province_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("省份ID");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(1)")
                    .HasComment("季度");

                entity.Property(e => e.SqName1)
                    .HasColumnName("sq_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SqName10)
                    .HasColumnName("sq_name10")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName100)
                    .HasColumnName("sq_name100")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName11)
                    .HasColumnName("sq_name11")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName12)
                    .HasColumnName("sq_name12")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName13)
                    .HasColumnName("sq_name13")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName14)
                    .HasColumnName("sq_name14")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName15)
                    .HasColumnName("sq_name15")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName16)
                    .HasColumnName("sq_name16")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName17)
                    .HasColumnName("sq_name17")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName18)
                    .HasColumnName("sq_name18")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName19)
                    .HasColumnName("sq_name19")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName2)
                    .HasColumnName("sq_name2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName20)
                    .HasColumnName("sq_name20")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName21)
                    .HasColumnName("sq_name21")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName22)
                    .HasColumnName("sq_name22")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName23)
                    .HasColumnName("sq_name23")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName24)
                    .HasColumnName("sq_name24")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName25)
                    .HasColumnName("sq_name25")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName26)
                    .HasColumnName("sq_name26")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName27)
                    .HasColumnName("sq_name27")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName28)
                    .HasColumnName("sq_name28")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName29)
                    .HasColumnName("sq_name29")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName3)
                    .HasColumnName("sq_name3")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName30)
                    .HasColumnName("sq_name30")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName31)
                    .HasColumnName("sq_name31")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName32)
                    .HasColumnName("sq_name32")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName33)
                    .HasColumnName("sq_name33")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName34)
                    .HasColumnName("sq_name34")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName35)
                    .HasColumnName("sq_name35")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName36)
                    .HasColumnName("sq_name36")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName37)
                    .HasColumnName("sq_name37")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName38)
                    .HasColumnName("sq_name38")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName39)
                    .HasColumnName("sq_name39")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName4)
                    .HasColumnName("sq_name4")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName40)
                    .HasColumnName("sq_name40")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName41)
                    .HasColumnName("sq_name41")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName42)
                    .HasColumnName("sq_name42")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName43)
                    .HasColumnName("sq_name43")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName44)
                    .HasColumnName("sq_name44")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName45)
                    .HasColumnName("sq_name45")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName46)
                    .HasColumnName("sq_name46")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName47)
                    .HasColumnName("sq_name47")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName48)
                    .HasColumnName("sq_name48")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName49)
                    .HasColumnName("sq_name49")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName5)
                    .HasColumnName("sq_name5")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName50)
                    .HasColumnName("sq_name50")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName51)
                    .HasColumnName("sq_name51")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName52)
                    .HasColumnName("sq_name52")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName53)
                    .HasColumnName("sq_name53")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName54)
                    .HasColumnName("sq_name54")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName55)
                    .HasColumnName("sq_name55")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName56)
                    .HasColumnName("sq_name56")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName57)
                    .HasColumnName("sq_name57")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName58)
                    .HasColumnName("sq_name58")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName59)
                    .HasColumnName("sq_name59")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName6)
                    .HasColumnName("sq_name6")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName60)
                    .HasColumnName("sq_name60")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName61)
                    .HasColumnName("sq_name61")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName62)
                    .HasColumnName("sq_name62")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName63)
                    .HasColumnName("sq_name63")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName64)
                    .HasColumnName("sq_name64")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName65)
                    .HasColumnName("sq_name65")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName66)
                    .HasColumnName("sq_name66")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName67)
                    .HasColumnName("sq_name67")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName68)
                    .HasColumnName("sq_name68")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName69)
                    .HasColumnName("sq_name69")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName7)
                    .HasColumnName("sq_name7")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName70)
                    .HasColumnName("sq_name70")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName71)
                    .HasColumnName("sq_name71")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName72)
                    .HasColumnName("sq_name72")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName73)
                    .HasColumnName("sq_name73")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName74)
                    .HasColumnName("sq_name74")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName75)
                    .HasColumnName("sq_name75")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName76)
                    .HasColumnName("sq_name76")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName77)
                    .HasColumnName("sq_name77")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName78)
                    .HasColumnName("sq_name78")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName79)
                    .HasColumnName("sq_name79")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName8)
                    .HasColumnName("sq_name8")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName80)
                    .HasColumnName("sq_name80")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName81)
                    .HasColumnName("sq_name81")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName82)
                    .HasColumnName("sq_name82")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName83)
                    .HasColumnName("sq_name83")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName84)
                    .HasColumnName("sq_name84")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName85)
                    .HasColumnName("sq_name85")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName86)
                    .HasColumnName("sq_name86")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName87)
                    .HasColumnName("sq_name87")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName88)
                    .HasColumnName("sq_name88")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName89)
                    .HasColumnName("sq_name89")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName9)
                    .HasColumnName("sq_name9")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName90)
                    .HasColumnName("sq_name90")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName91)
                    .HasColumnName("sq_name91")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName92)
                    .HasColumnName("sq_name92")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName93)
                    .HasColumnName("sq_name93")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName94)
                    .HasColumnName("sq_name94")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName95)
                    .HasColumnName("sq_name95")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName96)
                    .HasColumnName("sq_name96")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName97)
                    .HasColumnName("sq_name97")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName98)
                    .HasColumnName("sq_name98")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SqName99)
                    .HasColumnName("sq_name99")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SafeQuestioncount>(entity =>
            {
                entity.ToTable("safe_questioncount");

                entity.HasComment("省和地市安监人员季度安全生产检查发现的问题和隐患数量汇总统计表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Checkcount)
                    .HasColumnName("checkcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasComment("提交时间");

                entity.Property(e => e.CurrentStep)
                    .HasColumnName("current_step")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasComment("组织机构映射ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .HasColumnName("flow_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(1)")
                    .HasComment("季度");

                entity.Property(e => e.SqName1)
                    .HasColumnName("sq_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SqName10)
                    .HasColumnName("sq_name10")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName100)
                    .HasColumnName("sq_name100")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName11)
                    .HasColumnName("sq_name11")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName12)
                    .HasColumnName("sq_name12")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName13)
                    .HasColumnName("sq_name13")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName14)
                    .HasColumnName("sq_name14")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName15)
                    .HasColumnName("sq_name15")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName16)
                    .HasColumnName("sq_name16")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName17)
                    .HasColumnName("sq_name17")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName18)
                    .HasColumnName("sq_name18")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName19)
                    .HasColumnName("sq_name19")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName2)
                    .HasColumnName("sq_name2")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SqName20)
                    .HasColumnName("sq_name20")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName21)
                    .HasColumnName("sq_name21")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName22)
                    .HasColumnName("sq_name22")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName23)
                    .HasColumnName("sq_name23")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName24)
                    .HasColumnName("sq_name24")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName25)
                    .HasColumnName("sq_name25")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName26)
                    .HasColumnName("sq_name26")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName27)
                    .HasColumnName("sq_name27")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName28)
                    .HasColumnName("sq_name28")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName29)
                    .HasColumnName("sq_name29")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName3)
                    .HasColumnName("sq_name3")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName30)
                    .HasColumnName("sq_name30")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName31)
                    .HasColumnName("sq_name31")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName32)
                    .HasColumnName("sq_name32")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName33)
                    .HasColumnName("sq_name33")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName34)
                    .HasColumnName("sq_name34")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName35)
                    .HasColumnName("sq_name35")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName36)
                    .HasColumnName("sq_name36")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName37)
                    .HasColumnName("sq_name37")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName38)
                    .HasColumnName("sq_name38")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName39)
                    .HasColumnName("sq_name39")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName4)
                    .HasColumnName("sq_name4")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName40)
                    .HasColumnName("sq_name40")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName41)
                    .HasColumnName("sq_name41")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName42)
                    .HasColumnName("sq_name42")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName43)
                    .HasColumnName("sq_name43")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName44)
                    .HasColumnName("sq_name44")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName45)
                    .HasColumnName("sq_name45")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName46)
                    .HasColumnName("sq_name46")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName47)
                    .HasColumnName("sq_name47")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName48)
                    .HasColumnName("sq_name48")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName49)
                    .HasColumnName("sq_name49")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName5)
                    .HasColumnName("sq_name5")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName50)
                    .HasColumnName("sq_name50")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName51)
                    .HasColumnName("sq_name51")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName52)
                    .HasColumnName("sq_name52")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName53)
                    .HasColumnName("sq_name53")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName54)
                    .HasColumnName("sq_name54")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName55)
                    .HasColumnName("sq_name55")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName56)
                    .HasColumnName("sq_name56")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName57)
                    .HasColumnName("sq_name57")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName58)
                    .HasColumnName("sq_name58")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName59)
                    .HasColumnName("sq_name59")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName6)
                    .HasColumnName("sq_name6")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName60)
                    .HasColumnName("sq_name60")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName61)
                    .HasColumnName("sq_name61")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName62)
                    .HasColumnName("sq_name62")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName63)
                    .HasColumnName("sq_name63")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName64)
                    .HasColumnName("sq_name64")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName65)
                    .HasColumnName("sq_name65")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName66)
                    .HasColumnName("sq_name66")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName67)
                    .HasColumnName("sq_name67")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName68)
                    .HasColumnName("sq_name68")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName69)
                    .HasColumnName("sq_name69")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName7)
                    .HasColumnName("sq_name7")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName70)
                    .HasColumnName("sq_name70")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName71)
                    .HasColumnName("sq_name71")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName72)
                    .HasColumnName("sq_name72")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName73)
                    .HasColumnName("sq_name73")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName74)
                    .HasColumnName("sq_name74")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName75)
                    .HasColumnName("sq_name75")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName76)
                    .HasColumnName("sq_name76")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName77)
                    .HasColumnName("sq_name77")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName78)
                    .HasColumnName("sq_name78")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName79)
                    .HasColumnName("sq_name79")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName8)
                    .HasColumnName("sq_name8")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName80)
                    .HasColumnName("sq_name80")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName81)
                    .HasColumnName("sq_name81")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName82)
                    .HasColumnName("sq_name82")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName83)
                    .HasColumnName("sq_name83")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName84)
                    .HasColumnName("sq_name84")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName85)
                    .HasColumnName("sq_name85")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName86)
                    .HasColumnName("sq_name86")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName87)
                    .HasColumnName("sq_name87")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName88)
                    .HasColumnName("sq_name88")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName89)
                    .HasColumnName("sq_name89")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName9)
                    .HasColumnName("sq_name9")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName90)
                    .HasColumnName("sq_name90")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName91)
                    .HasColumnName("sq_name91")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName92)
                    .HasColumnName("sq_name92")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName93)
                    .HasColumnName("sq_name93")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName94)
                    .HasColumnName("sq_name94")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName95)
                    .HasColumnName("sq_name95")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName96)
                    .HasColumnName("sq_name96")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName97)
                    .HasColumnName("sq_name97")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName98)
                    .HasColumnName("sq_name98")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SqName99)
                    .HasColumnName("sq_name99")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Submitcount)
                    .HasColumnName("submitcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Totalcount)
                    .HasColumnName("totalcount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SafeRel>(entity =>
            {
                entity.ToTable("safe_rel");

                entity.HasComment("映射表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("字段中文描述");

                entity.Property(e => e.Formula)
                    .HasColumnName("formula")
                    .HasComment("公式");

                entity.Property(e => e.Inputrole)
                    .HasColumnName("inputrole")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("上报角色0 地市、省份填写1、省份填写2、地市填写");

                entity.Property(e => e.IsEdit)
                    .HasColumnName("is_edit")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否能编辑");

                entity.Property(e => e.IsExt)
                    .HasColumnName("is_ext")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否为扩展字段 0未扩展1扩展");

                entity.Property(e => e.IsMerge)
                    .HasColumnName("is_merge")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否是合并单元格");

                entity.Property(e => e.IsShow)
                    .HasColumnName("is_show")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("统计表格内是否显示,是否显示 1显示   0 不显示");

                entity.Property(e => e.IsShowForm)
                    .HasColumnName("is_show_form")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否在表单内显示");

                entity.Property(e => e.IsShowPie)
                    .HasColumnName("is_show_pie")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否在饼图内显示");

                entity.Property(e => e.IsSum)
                    .HasColumnName("is_sum")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否是合计项");

                entity.Property(e => e.Isleaf)
                    .HasColumnName("isleaf")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否是叶子节点");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)")
                    .HasComment("层级0-1-2");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("字段名称");

                entity.Property(e => e.OptTime)
                    .HasColumnName("opt_time")
                    .HasComment("操作时间");

                entity.Property(e => e.Pcoordinate)
                    .HasColumnName("pcoordinate")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("单元格地址");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)")
                    .HasComment("父级");

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasColumnType("int(11)")
                    .HasComment("季度");

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("合并节点范围");

                entity.Property(e => e.Sortby)
                    .HasColumnName("sortby")
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.TabId)
                    .HasColumnName("tab_id")
                    .HasColumnType("int(1)")
                    .HasComment("属于哪一个表");

                entity.Property(e => e.TreeCode)
                    .HasColumnName("tree_code")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("插件树代码");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)")
                    .HasComment("表单元素类型");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("季度所属的年");
            });

            modelBuilder.Entity<TableList>(entity =>
            {
                entity.ToTable("table_list");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TabCname)
                    .HasColumnName("tab_cname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("表中文描述");

                entity.Property(e => e.TabEname)
                    .HasColumnName("tab_ename")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("英文表名");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Username)
                    .HasName("login_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrowserVersion)
                    .HasColumnName("browser_version")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComment("浏览器版本");

                entity.Property(e => e.CaptchaMd5)
                    .HasColumnName("captchaMd5")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("验证码md5");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityId")
                    .HasColumnType("int(10)")
                    .HasComment("地市ID");

                entity.Property(e => e.CityName)
                    .HasColumnName("cityName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("地市名称");

                entity.Property(e => e.CountyId)
                    .HasColumnName("countyId")
                    .HasColumnType("int(10)")
                    .HasComment("维护中心ID");

                entity.Property(e => e.CountyName)
                    .HasColumnName("countyName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("维护中心名称");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasComment("创建时间");

                entity.Property(e => e.Creator)
                    .HasColumnName("creator")
                    .HasColumnType("int(10)")
                    .HasComment("创建者");

                entity.Property(e => e.CreatorName)
                    .HasColumnName("creatorName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("departmentId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("单位ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("departmentName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单位名称");

                entity.Property(e => e.IsChange)
                    .HasColumnName("is_change")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsLogin)
                    .HasColumnName("is_login")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0:锁死；1:正常");

                entity.Property(e => e.LogEntry)
                    .HasColumnName("log_entry")
                    .HasColumnType("int(11)")
                    .HasComment("登录入口 0 - 门户单点登录1 - 直接登录2 - 其他");

                entity.Property(e => e.LogInTime)
                    .HasColumnName("log_in_time")
                    .HasComment("登录时间");

                entity.Property(e => e.LogOutTime)
                    .HasColumnName("log_out_time")
                    .HasComment("退出时间");

                entity.Property(e => e.LogResult)
                    .HasColumnName("log_result")
                    .HasColumnType("tinyint(4)")
                    .HasComment("0 登陆成功 1登陆失败");

                entity.Property(e => e.LogWay)
                    .HasColumnName("log_way")
                    .HasColumnType("int(11)")
                    .HasComment("登陆方式 0 - 网页直接登录 1 - VPN登录 256 - 未知");

                entity.Property(e => e.LoginErr)
                    .HasColumnName("login_err")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("记录登陆错误次数");

                entity.Property(e => e.Mac)
                    .HasColumnName("MAC")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("员工登录OA或VPN过程使用的笔记本电脑/PC电脑对应的MAC地址");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(11)
                    .IsFixedLength()
                    .HasDefaultValueSql("'0'")
                    .HasComment("手机号");

                entity.Property(e => e.OsVersion)
                    .HasColumnName("os_version")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComment("操作系统版本");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'")
                    .HasComment("密码");

                entity.Property(e => e.PasswordMd5)
                    .HasColumnName("password_md5")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("加密密码");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasColumnType("int(10)")
                    .HasComment("省份ID");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("provinceName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("省份名称");

                entity.Property(e => e.RealName)
                    .HasColumnName("realName")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComment("真实姓名");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("int(11)")
                    .HasComment("角色ID");

                entity.Property(e => e.RoleLevel)
                    .HasColumnName("roleLevel")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'5'")
                    .HasComment("组织级别0，1，2，3，4，5");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("角色名称");

                entity.Property(e => e.SiteId)
                    .HasColumnName("siteId")
                    .HasColumnType("int(10)")
                    .HasComment("装维站id");

                entity.Property(e => e.SiteName)
                    .HasColumnName("siteName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("装维站");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否启用");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserMenu>(entity =>
            {
                entity.ToTable("user_menu");

                entity.HasComment("用户——权限映射表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MenuIds)
                    .HasColumnName("menuIds")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<WoAudit>(entity =>
            {
                entity.ToTable("wo_audit");

                entity.HasComment("工单审核列表");

                entity.HasIndex(e => e.WorkNumber)
                    .HasName("work_number");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.CDate)
                    .HasColumnName("c_date")
                    .HasComment("审核时间");

                entity.Property(e => e.CName)
                    .HasColumnName("c_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("审核人姓名");

                entity.Property(e => e.CUid)
                    .HasColumnName("c_uid")
                    .HasColumnType("int(11)")
                    .HasComment("审核人uid");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("int(11)")
                    .HasComment("市id");

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasComment("评论");

                entity.Property(e => e.CountyId)
                    .HasColumnName("county_id")
                    .HasColumnType("int(11)")
                    .HasComment("维护中心id");

                entity.Property(e => e.CountyName)
                    .HasColumnName("county_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OrgId)
                    .HasColumnName("org_id")
                    .HasColumnType("int(11)")
                    .HasComment("审核人组织机构id");

                entity.Property(e => e.OrgName)
                    .HasColumnName("org_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("审核人组织机构名称");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)")
                    .HasComment("省id");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("province_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("审核结果（1-合格 2-不合格）");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)")
                    .HasComment("角色id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("角色名称");

                entity.Property(e => e.SiteId)
                    .HasColumnName("site_id")
                    .HasColumnType("int(11)")
                    .HasComment("装维站id");

                entity.Property(e => e.SiteName)
                    .HasColumnName("site_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.WnOuid)
                    .HasColumnName("wn_ouid")
                    .HasColumnType("int(11)")
                    .HasComment("工单组织id");

                entity.Property(e => e.WnRealname)
                    .HasColumnName("wn_realname")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("工单人名称");

                entity.Property(e => e.WnTime)
                    .HasColumnName("wn_time")
                    .HasComment("工单时间");

                entity.Property(e => e.WnUsername)
                    .HasColumnName("wn_username")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("工单人username");

                entity.Property(e => e.WorkNumber)
                    .IsRequired()
                    .HasColumnName("work_number")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'")
                    .HasComment("工单编号");
            });

            modelBuilder.Entity<WoAuditRes>(entity =>
            {
                entity.ToTable("wo_audit_res");

                entity.HasComment("工单审核结果表");

                entity.HasIndex(e => e.WorkNumber)
                    .HasName("work_number");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("审核结果（1-合格 2-不合格）");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("int(11)")
                    .HasComment("角色id");

                entity.Property(e => e.WorkNumber)
                    .IsRequired()
                    .HasColumnName("work_number")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'")
                    .HasComment("工单编号");
            });

            modelBuilder.Entity<WorkOrganization>(entity =>
            {
                entity.HasKey(e => e.OuId)
                    .HasName("PRIMARY");

                entity.ToTable("work_organization");

                entity.HasIndex(e => e.OuLevel)
                    .HasName("indexLevel");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("i_prid");

                entity.Property(e => e.OuId)
                    .HasColumnName("ou_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AreaId)
                    .HasColumnName("area_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("所属地市名称");

                entity.Property(e => e.CityId)
                    .HasColumnName("CityID")
                    .HasColumnType("int(11)")
                    .HasComment("所属地市ID");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("所属经营部名称");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasColumnType("int(11)")
                    .HasComment("所属经营部ID");

                entity.Property(e => e.InName)
                    .HasColumnName("in_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''")
                    .HasComment("对内名称");

                entity.Property(e => e.OuLevel)
                    .HasColumnName("ou_level")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OuName)
                    .HasColumnName("ou_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("所属省名称");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceID")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
