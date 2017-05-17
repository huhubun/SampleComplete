# ASP.NET Web API: Add paging info to Link Header

See [RFC 5988 - Web Linking](https://tools.ietf.org/html/rfc5988#section-5)

## Response Header

(Insert line for higher readability in this sample)
```
Link: <http://localhost:31272/api/Todos?keyword=test&pageSize=5&page=1>; rel="first",
	<http://localhost:31272/api/Todos?keyword=test&pageSize=5&page=1>; rel="prev",
	<http://localhost:31272/api/Todos?keyword=test&pageSize=5&page=3>; rel="next",
	<http://localhost:31272/api/Todos?keyword=test&pageSize=5&page=4>; rel="last"
```
