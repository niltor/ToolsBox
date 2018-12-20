from .Service import Service


class RequestTest(Service):
    def __init__(self, url=None, cookie=None, timeout=None):
        super().__init__(url, cookie, timeout)

    def getXXX(self, data=None):
        url = ''
        if data:
            for (key, value) in data:
                url = url + key + '=' + value + '&'

        print('get')
        return super().get(url)

    def postXXX(self, data):
        return super().post("", data=data, json=None)
