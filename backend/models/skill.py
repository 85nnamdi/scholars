from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Skill model
class Skill(BaseModel):
    id: Optional[int]
    name: str
    created_at: Optional[datetime] = datetime.now()
