from pymongo import MongoClient

from motor.motor_asyncio import AsyncIOMotorClient
# Connect to MongoDB using Motor
client = AsyncIOMotorClient("mongodb://localhost:27017")
db = client["scholars_db"]

# # Connect to MongoDB using PyMongo
# client = MongoClient("mongodb://localhost:27017/")
# db = client["scholars_db"]

# # # Example: Accessing a collection
# # collection_name = db["scholars_db"]

# # db = client.scholars_db
# collection_name = db["scholars_db"]
# collection_user = db["user"]
# collection_institution = db["institution"]