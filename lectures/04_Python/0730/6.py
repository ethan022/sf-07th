import requests

url = "https://koreanjson.com/posts"
res = requests.get(url)

print(res)
