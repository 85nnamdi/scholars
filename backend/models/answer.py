from pydantic import BaseModel
from typing import Optional
from datetime import datetime

# Answer model
class Answer(BaseModel):
    id: Optional[int]
    content: str
    question_id: int  # Foreign key to questions
    user_id: int  # Foreign key to users
    created_at: Optional[datetime] = datetime.now()
