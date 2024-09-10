from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Question model
class Question(BaseModel):
    id: Optional[int]
    title: str
    content: str
    user_id: int  # Foreign key to users
    created_at: Optional[datetime] = datetime.now()
