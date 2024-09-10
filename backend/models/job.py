from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Job model
class Job(BaseModel):
    id: Optional[int]
    title: str
    description: str
    institution_id: int  # Foreign key to institutions
    created_at: Optional[datetime] = datetime.now()
