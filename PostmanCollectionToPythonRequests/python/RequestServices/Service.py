import requests
import json
import time
import codecs


class Service(object):
    baseApiUrl = 'http://localhost/'
    cookie = {"PHPSESSID": ""}
    timeout = 5

    def __init__(self, url=None, cookie=None, timeout=None):
        if url:
            self.baseApiUrl = url
        if cookie:
            self.cookie = cookie
        if timeout:
            self.timeout = timeout

    def post(self, url, data=None, json=None):
        startTime = time.time()
        path = url
        url = self.baseApiUrl + url
        header = {'Content-Type': 'application/json'}

        if data != None:
            with requests.post(url, headers=header, data=data, cookies=self.cookie, timeout=self.timeout) as r:
                try:
                    if(r.ok):
                        print(r.text)
                        self.log('接口:[' + path + ']耗时:' +
                             '[{:.2f}]'.format(time.time() - startTime) + '秒')
                    else:
                        print('接口:[' + path + ']:'+str(r.status_code))

                    return r.text
                except Exception as e:
                    print('接口:[' + path + '] 异常')
                    print(e)
                    return None

        if json != None:
            with requests.post(url, cookies=self.cookie, headers=header, json=json, timeout=self.timeout) as r:
                try:
                    if(r.ok):
                        print(r.text)
                        self.log('接口:[' + path + ']耗时:' +
                             '[{:.2f}]'.format(time.time() - startTime) + '秒')
                    else:
                        print('接口:[' + path + ']:'+str(r.status_code))
                    return r.text
                except Exception as e:
                    print('接口:[' + path + '] 异常')
                    print(e)
                    return None

    def get(self, url):
        startTime = time.time()
        path = url
        url = self.baseApiUrl + url
        with requests.get(url, cookies=self.cookie, timeout=self.timeout) as r:
            try:
                if(r.ok):
                    print(r.text)

                    self.log('接口:[' + path + ']耗时:' +
                            '[{:.2f}]'.format(time.time() - startTime) + '秒')
                else:
                    print('接口:[' + path + ']:'+str(r.status_code))
                return r.text
            except Exception as e:
                print('接口:[' + path + '] 异常')
                print(str(e))
                return None

    def log(self, content):
        with codecs.open('./log.txt', 'a', 'utf-8') as f:
            f.write(content + '\r\n')
