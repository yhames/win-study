from fastapi import FastAPI
from pydantic import BaseModel
from typing import List
from datetime import date

app = FastAPI()


# ----------------------------
# 📦 Pagination DTO
# ----------------------------
class PaginationMetadata(BaseModel):
    page: int
    totalCount: int

class PaginationContent(BaseModel):
    pagintaion: PaginationMetadata
    data: List

class PaginationResponse(BaseModel):
    result: bool
    content: PaginationContent
    message: str


# ----------------------------
# 👤 User DTO
# ----------------------------
class MUser(BaseModel):
    id: str
    userId: str
    name: str

class DUser(BaseModel):
    id: str
    userId: str
    email: str
    address: str
    phoneNumber: str
    dateOfBirth: date
    gender: str
    occupation: str
    nationality: str
    profilePictureUrl: str


# ----------------------------
# 📝 Post DTO
# ----------------------------
class MPost(BaseModel):
    id: str
    userId: str
    title: str

class DPost(BaseModel):
    id: int
    postId: int
    content: str


# ----------------------------
# 🔗 유저 목록 API
# ----------------------------
@app.get("/api/users", response_model=PaginationResponse)
async def get_users(page: int = 1, perPage: int = 10):
    users = [
        MUser(id="1", userId="user01", name="홍길동"),
        MUser(id="2", userId="user02", name="김철수"),
        MUser(id="3", userId="user03", name="이영희")
    ]
    total_count = len(users)

    return {
        "result": True,
        "content": {
            "pagintaion": {
                "page": page,
                "totalCount": total_count
            },
            "data": users[(page-1)*perPage: page*perPage]
        },
        "message": "Success"
    }


# ----------------------------
# 🔗 유저 상세 API
# ----------------------------
@app.get("/api/users/detail/{m_user_id}", response_model=DUser)
async def get_user_detail(m_user_id: int):
    return DUser(
        id=str(m_user_id),
        userId=f"user0{m_user_id}",
        email="user@example.com",
        address="서울시 강남구",
        phoneNumber="010-1234-5678",
        dateOfBirth="1990-01-01",
        gender="남성",
        occupation="개발자",
        nationality="대한민국",
        profilePictureUrl="https://via.placeholder.com/150"
    )


# ----------------------------
# 🔗 포스트 목록 API
# ----------------------------
@app.get("/posts", response_model=PaginationResponse)
async def get_posts(page: int = 1, perPage: int = 10):
    posts = [
        MPost(id="1", userId="user01", title="첫 번째 게시글"),
        MPost(id="2", userId="user02", title="두 번째 게시글"),
        MPost(id="3", userId="user03", title="세 번째 게시글")
    ]
    total_count = len(posts)

    return {
        "result": True,
        "content": {
            "pagintaion": {
                "page": page,
                "totalCount": total_count
            },
            "data": posts[(page-1)*perPage: page*perPage]
        },
        "message": "Success"
    }


# ----------------------------
# 🔗 포스트 상세 API
# ----------------------------
@app.get("/api/posts/detail/{post_id}", response_model=DPost)
async def get_post_detail(post_id: int):
    return DPost(
        id=post_id,
        postId=post_id,
        content="이것은 상세 게시글 내용입니다."
    )
