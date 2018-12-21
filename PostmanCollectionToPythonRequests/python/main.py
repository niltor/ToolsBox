import codecs


def log(content):
    with codecs.open('./log.txt', 'a', 'utf-8') as f:
        f.write(content+'\r\n')


log("第一行")
log("第二行")
