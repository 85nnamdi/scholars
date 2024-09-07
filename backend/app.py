import os
from fastapi import FastAPI, HTTPException
from motor.motor_asyncio import AsyncIOMotorClient
from models import *
from bson import ObjectId
from datetime import datetime

app = FastAPI()

# Connect to MongoDB
client = AsyncIOMotorClient("mongodb://localhost:27017")
db = client["scholars_db"]

# Create Institution
@app.post("/institutions/")
async def create_institution(institution: Institution):
    institution_data = institution.dict()
    institution_data["created_at"] = datetime.utcnow()
    result = await db["institutions"].insert_one(institution_data)
    return {"id": str(result.inserted_id)}

# Get Institutions
@app.get("/institutions/")
async def get_institutions():
    institutions = []
    async for institution in db["institutions"].find():
        institutions.append(Institution(**institution))
    return institutions

# Create User
@app.post("/users/")
async def create_user(user: User):
    user_data = user.dict()
    user_data["created_at"] = datetime.utcnow()
    result = await db["users"].insert_one(user_data)
    return {"id": str(result.inserted_id)}

# Get Users
@app.get("/users/")
async def get_users():
    users = []
    async for user in db["users"].find():
        users.append(User(**user))
    return users

# Create Publication
@app.post("/publications/")
async def create_publication(publication: Publication):
    publication_data = publication.dict()
    publication_data["created_at"] = datetime.utcnow()
    result = await db["publications"].insert_one(publication_data)
    return {"id": str(result.inserted_id)}

# Get Publications
@app.get("/publications/")
async def get_publications():
    publications = []
    async for publication in db["publications"].find():
        publications.append(Publication(**publication))
    return publications

# Create Project
@app.post("/projects/")
async def create_project(project: Project):
    project_data = project.dict()
    project_data["created_at"] = datetime.utcnow()
    result = await db["projects"].insert_one(project_data)
    return {"id": str(result.inserted_id)}

# Get Projects
@app.get("/projects/")
async def get_projects():
    projects = []
    async for project in db["projects"].find():
        projects.append(Project(**project))
    return projects

# Create Question
@app.post("/questions/")
async def create_question(question: Question):
    question_data = question.dict()
    question_data["created_at"] = datetime.utcnow()
    result = await db["questions"].insert_one(question_data)
    return {"id": str(result.inserted_id)}

# Get Questions
@app.get("/questions/")
async def get_questions():
    questions = []
    async for question in db["questions"].find():
        questions.append(Question(**question))
    return questions

# Create Answer
@app.post("/answers/")
async def create_answer(answer: Answer):
    answer_data = answer.dict()
    answer_data["created_at"] = datetime.utcnow()
    result = await db["answers"].insert_one(answer_data)
    return {"id": str(result.inserted_id)}

# Get Answers
@app.get("/answers/")
async def get_answers():
    answers = []
    async for answer in db["answers"].find():
        answers.append(Answer(**answer))
    return answers

# Create Follower
@app.post("/followers/")
async def create_follower(follower: Follower):
    follower_data = follower.dict()
    follower_data["created_at"] = datetime.utcnow()
    result = await db["followers"].insert_one(follower_data)
    return {"id": str(result.inserted_id)}

# Get Followers
@app.get("/followers/")
async def get_followers():
    followers = []
    async for follower in db["followers"].find():
        followers.append(Follower(**follower))
    return followers

# Create Skill
@app.post("/skills/")
async def create_skill(skill: Skill):
    skill_data = skill.dict()
    skill_data["created_at"] = datetime.utcnow()
    result = await db["skills"].insert_one(skill_data)
    return {"id": str(result.inserted_id)}

# Get Skills
@app.get("/skills/")
async def get_skills():
    skills = []
    async for skill in db["skills"].find():
        skills.append(Skill(**skill))
    return skills

# Create UserSkill
@app.post("/user_skills/")
async def create_user_skill(user_skill: UserSkill):
    user_skill_data = user_skill.dict()
    user_skill_data["created_at"] = datetime.utcnow()
    result = await db["user_skills"].insert_one(user_skill_data)
    return {"id": str(result.inserted_id)}

# Get UserSkills
@app.get("/user_skills/")
async def get_user_skills():
    user_skills = []
    async for user_skill in db["user_skills"].find():
        user_skills.append(UserSkill(**user_skill))
    return user_skills

# Create Job
@app.post("/jobs/")
async def create_job(job: Job):
    job_data = job.dict()
    job_data["created_at"] = datetime.utcnow()
    result = await db["jobs"].insert_one(job_data)
    return {"id": str(result.inserted_id)}

# Get Jobs
@app.get("/jobs/")
async def get_jobs():
    jobs = []
    async for job in db["jobs"].find():
        jobs.append(Job(**job))
    return jobs

# Create Message
@app.post("/messages/")
async def create_message(message: Message):
    message_data = message.dict()
    message_data["created_at"] = datetime.utcnow()
    result = await db["messages"].insert_one(message_data)
    return {"id": str(result.inserted_id)}

# Get Messages
@app.get("/messages/")
async def get_messages():
    messages = []
    async for message in db["messages"].find():
        messages.append(Message(**message))
    return messages

# Create Notification
@app.post("/notifications/")
async def create_notification(notification: Notification):
    notification_data = notification.dict()
    notification_data["created_at"] = datetime.utcnow()
    result = await db["notifications"].insert_one(notification_data)
    return {"id": str(result.inserted_id)}

# Get Notifications
@app.get("/notifications/")
async def get_notifications():
    notifications = []
    async for notification in db["notifications"].find():
        notifications.append(Notification(**notification))
    return notifications
