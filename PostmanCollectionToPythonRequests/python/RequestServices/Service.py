import requests
import json
import time
import codecs

class Service(object):
    baseApiUrl = 'http://localhost/api/'
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
        url = self.baseApiUrl + url
        header = {'Content-Type': 'application/json'}
        if (data != None):
            r = requests.post(url, headers=header, data=data, cookie=self.cookie,
                              timeout=self.timeout)
        if (json != None):
            r = requests.post(url, cookies=self.cookie,
                              headers=header, json=json, timeout=self.timeout)

        log('接口:[' + url + ']耗时:' + '[{:.2f}]'.format(time.time() - startTime) + '秒')
        return r.text

    def get(self, url):
        startTime = time.time()
        url = self.baseApiUrl + url
        r = requests.get(url, cookies=self.cookie, timeout=self.timeout)
        log('接口:[' + url + ']耗时:' + '[{:.2f}]'.format(time.time() - startTime) + '秒')
        return r.text


    def log(self,content):
        with codecs.open('./log.txt','a','utf-8') as f:
            f.write(content + '\r\n')
