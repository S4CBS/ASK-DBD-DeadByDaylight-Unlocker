import requests

"""
GET /api/v1/match/376a04a1-56f7-4243-8efa-417066a6b7b4 HTTP/1.1
Host: egs.live.bhvrdbd.com
Accept: */*
Accept-Encoding: deflate, gzip
Cookie: bhvrSession=gBy5eCxDRQv_HFGbrC272A.yg-jNFPXdVPFQjpJAKYX9Q4tGFIb6iy07EpZCi5jZnkviLUvuUZDk8vwdmXavVGZTng-JFEVtamCNDJaoQSMkTj-J2YM3ZQ_HPm_ttu_NKAfG7ruCC9LTdm1IOxP2x3CyZfLQaD4iwaKuw9pc4-32k0Hqwo7cuvbdauZK7IF0XWb350ZQlrmaPFO1CUwlnNEuEsQZ55ewPoBdj_V7QZOc0GgEraTZsJzyNtkZxC3ttBD0aBeEGz4W85nSceh6_Z66lXhnCerttZW5ek8tCIZdw.1734864381931.86400000.i_8xu_HB8WXFKy-6iwvXZG3Rer4VsCUZ0imlALbmBIU
Content-Type: application/json
x-kraken-analytics-session-id: 5a662dd1-432c-52aa-52bb-e380ee1f07b3
x-kraken-client-platform: egs
x-kraken-client-provider: egs
x-kraken-client-resolution: 1920x1080
x-kraken-client-timezone-offset: -180
x-kraken-client-os: 10.0.26100.1.256.64bit
x-kraken-client-version: 8.4.2
api-key: d37052ed-7836-42f5-a4d1-464da5ba29d7
User-Agent: DeadByDaylight/DBD_Gelato_HF2_EGS_Shipping_6_2203069 EGS/10.0.26100.1.256.64bit
Content-Length: 0
"""

url = "https://egs.live.bhvrdbd.com/api/v1/match/376a04a1-56f7-4243-8efa-417066a6b7b4"
headers = {
    "Accept": "*/*",
    "Accept-Encoding": "deflate, gzip",
    "Cookie": "bhvrSession=gBy5eCxDRQv_HFGbrC272A.yg-jNFPXdVPFQjpJAKYX9Q4tGFIb6iy07EpZCi5jZnkviLUvuUZDk8vwdmXavVGZTng-JFEVtamCNDJaoQSMkTj-J2YM3ZQ_HPm_ttu_NKAfG7ruCC9LTdm1IOxP2x3CyZfLQaD4iwaKuw9pc4-32k0Hqwo7cuvbdauZK7IF0XWb350ZQlrmaPFO1CUwlnNEuEsQZ55ewPoBdj_V7QZOc0GgEraTZsJzyNtkZxC3ttBD0aBeEGz4W85nSceh6_Z66lXhnCerttZW5ek8tCIZdw.1734864381931.86400000.i_8xu_HB8WXFKy-6iwvXZG3Rer4VsCUZ0imlALbmBIU",
    "Content-Type": "application/json",
    "x-kraken-analytics-session-id": "5a662dd1-432c-52aa-52bb-e380ee1f07b3",
    "x-kraken-client-platform": "egs",
    "x-kraken-client-provider": "egs",
    "x-kraken-client-resolution": "1920x1080",
    "x-kraken-client-timezone-offset": "-180",
    "x-kraken-client-os": "10.0.26100.1.256.64bit",
    "x-kraken-client-version": "8.4.2",
    "api-key": "d37052ed-7836-42f5-a4d1-464da5ba29d7",
    "User-Agent": "DeadByDaylight/DBD_Gelato_HF2_EGS_Shipping_6_2203069 EGS/10.0.26100.1.256.64bit",
}

response = requests.get(url, headers=headers, verify=False)

print(response.text)
