## .Net Core API Challenge
The code compiles right out of the box; of course provided you internet connection needed to restore all the nugget packages.
We made use of .Net 5 with the following packages:
 - Microsoft.AspNetCore.Authentication.JwtBearer:  Version="5.0.7" 
 - Microsoft.EntityFrameworkCore.SqlServer : Version="5.0.7" 
 - Microsoft.EntityFrameworkCore.Tools: Version="5.0.7"
 - Swashbuckle.AspNetCore:  Version="6.1.4"

 Note that we are developping on Microsoft Visual Studio Community 2019 (Version 16.9.2)
 This document read_me is based on the onboad swagger. note that postman collection are also available at the bottom.
 The default port is: **3000**; use **hosting.jsn** to set desired port

## SQL  Server connection
Note that the Sql connection string is required in order to make the whole Api project to work.
Whether the app usersecrets config or appsettings are used, the connection string has to figure somewhere in the format below: 
```json{
"ConnectionStrings:OnlineCourseDatabase": "Server=ELZA2;Database=topcoder_database;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
Note that the key: ***ConnectionStrings:OnlineCourseDatabase*** is required as that the hardcoded location where the application attempt read the connection from the configuration.

## First Run

Once the connections string has been inserted, the solution can be run. if the connection string are right that here what happen at first run. Since the code run first is used here; the app will check if the database (as specified in Sql Server connection) and all table and file has been create. If not, then if will apply the migrations hence creating the complete database.
Note than for testing, purpose, once the migration is complete; the  application will proceed onto creating a root user named: **root**, a course named: **root course**, a section named: **root section** and a lesson name: **root lesson**

## Swagger
Once project has run and has ensured proper initialization of the database, a swagger page will be opened.
Note that all test were done through swagger. 
On swagger page all necessary controllers/methods needed to authenticate, request token, request detailed lesson or create a watchLog are listed. To activate a method on a given controllers ensure that **Try it out** is pressed first.

## Login 
[http://localhost:3000/login](http://localhost:3000/login) (post)
To perform the login test which is authenticating the user to the database and then returning the token that will allow access to the rest of the api.
Navigate to swagger, on the locate the login controller, then do a login post. the LoginModel require a full-name and a password, but in this scope only the full-name is required.
A default user full-name is already given which is **root**
Fill in the root for FullName than press execute.
Once success a token then is returned in the sample format below:

```json
{ "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyMzllYzViMC1hMmQzLTQ0ZjItOTAzNi0xMWNiNWM4MjE0ZmQiLCJqdGkiOiIwNTYzMzY5MC0wNWZlLTQ0NDAtYmJjOS1hMDg0OWM0YmQxZGEiLCJleHAiOjE2MjQ1ODAyMzIsImlzcyI6ImNoYXByZXNvZnQuY29tIiwiYXVkIjoiY2hhcHJlc29mdC5jb20ifQ.Es0xg3vnHh_92hOnBe6pvtapPU9tsNZv6d-fq-y-h7E" }
```
## Authorization

Note that Swagger was configured in such a way to have a little authorization at the top right corner. click on the button; then it will show a dialog where the token should be passed. press authorize then close the dialog.
From now on all request will have the token along.


## GET /lesson/{id}
We know by now we have at least one lesson known as **root lesson**.
Locate ***Lessons controller*** on swagger and do a get which we'll return all lesson with ids.
See response sample below:
```json
[
  {
    "Id": "0f3099a0-386e-4837-bab1-08d9373d71a2",
    "Name": "root lesson",
    "VideoUrl": "00000000-0000-0000-0000-000000000000",
    "Order": 54,
    "Section": null,
    "IsCompleted": false
  }
]
```
With this response we can pick the Id of the only lesson to perform a get GET /lesson/{id}.
```json
{
  "Id": "0f3099a0-386e-4837-bab1-08d9373d71a2",
  "Name": "root lesson",
  "VideoUrl": "00000000-0000-0000-0000-000000000000",
  "Order": 54,
  "Section": {
    "Id": "e7b31289-daf4-4732-25b8-08d9373d719d",
    "Name": "root section",
    "Order": 92,
    "Course": {
      "Id": "3e6c93e7-9d1a-42e7-3028-08d9373d7195",
      "Name": "root course"
    }
  },
  "IsCompleted": false
}
```

## POST /watchLog/{lessonId}?pw={percentageWatched}
Locate the **WatchLog Controller**, there is a post method that accept lessonId and percentageWatched.
Still with the lesson id given abode, we fill the respective field, pw can be any number between 0 and 100.
Once this request is performed, we can expect 5 processes happen:

 1. The current active user is retrieve from user **HttpContext** (Identity claims)
 2. The lesson is retrieve from the provided **LessonId**
 3. The **Course** is retrieve along with  the section from the lesson, so it is available
 4. A **WatchLog** entry is then created with all field above populated then inserted into the database
 5. **IsCompleted** field of the lesson given by the **lessonId** is set to true then updated on the database
 6. 
## Final Result
Final output sample with **IsCompleted** switched to tru
```json
[
  {
    "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "Name": "string",
    "VideoUrl": "string",
    "Order": 0,
    "Section": {
      "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "Name": "string",
      "Order": 0,
      "Course": {
        "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "Name": "string"
      }
    },
    "IsCompleted": true
  }
]
```

## Postman Collection
Below is the Postman collection; replace ids or token where necessary
```json
{
{
	"info": {
		"_postman_id": "9f2c3d30-d70e-4df8-9086-e37644dd430e",
		"name": ".Net Core API Challenge",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "Autheticate&TokenRequest",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n  \"FullName\": \"root\",\r\n  \"Password\": \"string\"\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:3000/login",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "3000",
					"path": [
						"login"
					]
				}
			},
			"response": []
		},
		{
			"name": "GetLessons",
			"request": {
				"auth": {
					"type": "bearer",
					"bearer": [
						{
							"key": "token",
							"value": "put token here",
							"type": "string"
						}
					]
				},
				"method": "GET",
				"header": [],
				"url": {
					"raw": "http://localhost:3000/lesson",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "3000",
					"path": [
						"lesson"
					]
				}
			},
			"response": []
		},
		{
			"name": "GetLesson",
			"request": {
				"auth": {
					"type": "bearer",
					"bearer": [
						{
							"key": "token",
							"value": "put token here",
							"type": "string"
						}
					]
				},
				"method": "GET",
				"header": [],
				"url": {
					"raw": "http://localhost:3000/lesson/:id?pw=0",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "3000",
					"path": [
						"lesson",
						":id"
					],
					"query": [
						{
							"key": "pw",
							"value": "0"
						}
					],
					"variable": [
						{
							"key": "id",
							"value": "0f3099a0-386e-4837-bab1-08d9373d71a2"
						}
					]
				}
			},
			"response": []
		},
		{
			"name": "RecordWatchLog",
			"request": {
				"auth": {
					"type": "bearer",
					"bearer": [
						{
							"key": "token",
							"value": "put token here",
							"type": "string"
						}
					]
				},
				"method": "POST",
				"header": [],
				"url": {
					"raw": "http://localhost:3000/watchLog/:lessonId?pw=12",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "3000",
					"path": [
						"watchLog",
						":lessonId"
					],
					"query": [
						{
							"key": "pw",
							"value": "12"
						}
					],
					"variable": [
						{
							"key": "lessonId",
							"value": "0f3099a0-386e-4837-bab1-08d9373d71a2"
						}
					]
				}
			},
			"response": []
		},
		{
			"name": "GetLesson Copy",
			"request": {
				"auth": {
					"type": "bearer",
					"bearer": [
						{
							"key": "token",
							"value": "put token here",
							"type": "string"
						}
					]
				},
				"method": "GET",
				"header": [],
				"url": {
					"raw": "http://localhost:3000/lesson/:id?pw&=0",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "3000",
					"path": [
						"lesson",
						":id"
					],
					"query": [
						{
							"key": "pw",
							"value": null
						},
						{
							"key": null,
							"value": "0"
						}
					],
					"variable": [
						{
							"key": "id",
							"value": "0f3099a0-386e-4837-bab1-08d9373d71a2"
						}
					]
				}
			},
			"response": []
		}
	],
	"auth": {
		"type": "bearer"
	},
	"event": [
		{
			"listen": "prerequest",
			"script": {
				"type": "text/javascript",
				"exec": [
					""
				]
			}
		},
		{
			"listen": "test",
			"script": {
				"type": "text/javascript",
				"exec": [
					""
				]
			}
		}
	]
}
```