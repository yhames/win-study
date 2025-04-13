from fastapi import FastAPI, Query, HTTPException
from fastapi.responses import JSONResponse

app = FastAPI()

# mock data
m_users = [
    {"Id": "1", "UserId": "user01", "Name": "홍길동"},
    {"Id": "2", "UserId": "user02", "Name": "김철수"}
]

d_users = {
    "1": {
        "Id": "1",
        "UserId": "user01",
        "Email": "hong@example.com",
        "Address": "서울시 강남구",
        "PhoneNumber": "010-1234-5678",
        "DateOfBirth": "1990-01-01",
        "Gender": "남성",
        "Occupation": "개발자",
        "Nationality": "대한민국",
        "ProfilePictureUrl": "https://example.com/profile/1.jpg"
    },
    "2": {
        "Id": "2",
        "UserId": "user02",
        "Email": "kim@example.com",
        "Address": "부산시 해운대구",
        "PhoneNumber": "010-8765-4321",
        "DateOfBirth": "1992-05-10",
        "Gender": "여성",
        "Occupation": "디자이너",
        "Nationality": "대한민국",
        "ProfilePictureUrl": "https://example.com/profile/2.jpg"
    }
}

m_posts = [
    {"Id": "101", "UserId": "user01", "Title": "첫 번째 글"},
    {"Id": "102", "UserId": "user02", "Title": "두 번째 글"}
]

d_posts = {
    101: {"Id": 1, "PostId": 101, "Content": "이건 첫 번째 게시글의 내용입니다."},
    102: {"Id": 2, "PostId": 102, "Content": "이건 두 번째 게시글의 내용입니다."}
}

# --- API routes ---
@app.get("/api/users")
def get_m_users():
    return m_users

@app.get("/api/users/detail")
def get_d_user(id: str = Query(...)):
    user = d_users.get(id)
    if not user:
        raise HTTPException(status_code=404, detail="User not found")
    return user

@app.get("/api/posts")
def get_m_posts():
    return m_posts

@app.get("/api/posts/detail")
def get_d_post(id: int = Query(...)):
    post = d_posts.get(id)
    if not post:
        raise HTTPException(status_code=404, detail="Post not found")
    return post
