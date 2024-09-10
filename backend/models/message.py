from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Message model
class Message(BaseModel):
    id: Optional[int]
    content: str
    sender_id: int  # Foreign key to users (sender)
    receiver_id: int  # Foreign key to users (receiver)
    created_at: Optional[datetime] = datetime.now()
