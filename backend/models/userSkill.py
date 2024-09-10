from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# UserSkill model
class UserSkill(BaseModel):
    id: Optional[int]
    user_id: int  # Foreign key to users
    skill_id: int  # Foreign key to skills
    created_at: Optional[datetime] = datetime.now()
