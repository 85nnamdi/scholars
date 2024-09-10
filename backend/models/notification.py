from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Notification model
class Notification(BaseModel):
    id: Optional[int]
    content: str
    user_id: int  # Foreign key to users
    created_at: Optional[datetime] = datetime.now()