from pydantic import BaseModel, EmailStr,SecretStr
from typing import Optional
from datetime import datetime
# User model
class User(BaseModel):
    id: Optional[int]
    name: str
    email: EmailStr  # Pydantic provides EmailStr for email validation
    password: str
    institution_id: Optional[int]  # Nullable foreign key
    created_at: Optional[datetime] = datetime.now()
