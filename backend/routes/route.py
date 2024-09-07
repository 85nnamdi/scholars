from fastapi import APIRouter
from models import User, Institution
from config.database import db
from schema.schemas import user_list_serial, institution_list_serial
from bson import ObjectId


router = APIRouter()

# # Get Users
# @router.get("/institution")
# async def get_institutions():
#     institution = collection_institution.find()
#     return institution_list_serial(institution)

# # Post Users
# @router.post("/institution")
# async def create_institution(institution: Institution):
#     collection_institution.insert_one(institution.dict())
#     return institution_list_serial(collection_institution.find())


# # Get Users
# @router.get("/user")
# async def get_user():
#     users = collection_name.find()
#     return user_list_serial(users)

# # Post Users
# @router.post("/user")
# async def create_user(user: User):
#     collection_name.insert_one(user.dict())
#     return user_list_serial(collection_name.find())


# Get Users
@router.get("/userse/")
async def get_users():
    users = []
    async for user in db["users"].find():
        users.append(User(**user))
    return users
