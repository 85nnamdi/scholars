from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Project model
class Project(BaseModel):
    id: Optional[int]
    title: str
    description: str
    user_id: int  # Foreign key to users
    created_at: Optional[datetime] = datetime.now()
