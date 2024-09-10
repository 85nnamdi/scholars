from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Publication model
class Publication(BaseModel):
    id: Optional[int]
    title: str
    abstract: str
    content: str
    user_id: int  # Foreign key to users
    type: str
    created_at: Optional[datetime] = datetime.now()
