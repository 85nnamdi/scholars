from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Follower model
class Follower(BaseModel):
    id: Optional[int]
    follower_id: int  # Foreign key to users (follower)
    followed_id: int  # Foreign key to users (followed)
    created_at: Optional[datetime] = datetime.now()
