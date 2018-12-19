import requests
import json


class Service(object):
    baseApiUrl = 'http://localhost/api/'
    cookie = {"PHPSESSID": ""}
    timeout = 5

    def __init__(self, url=None, cookie=None, timeout=None):
        if url != None:
            self.baseApiUrl = url
        if cookie != None:
            self.cookie = cookie
        if timeout != None:
            self.timeout = timeout

    def post(self, url, data=None, json=None):
        url = self.baseApiUrl+url
        header = {'Content-Type': 'application/json'}
        if (data != None):
            r = requests.post(url, headers=header, data=data, cookie=self.cookie,
                              timeout=self.timeout)
        if (json != None):
            r = requests.post(url, cookies=self.cookie,
                              headers=header, json=json, timeout=self.timeout)
        return r.text

    def get(self, url):
        url = self.baseApiUrl+url
        r = requests.get(url, cookies=self.cookie, timeout=self.timeout)
        return r.text
