def institution_serial(institution)->dict:
    return {
        "id": str(institution["_id"]),
        "name": institution["name"],
       "location": institution["location"],
        "created_at": institution["created_at"]
    }

def user_serial(user)->dict:
    return{
        "id": str(user["_id"]),
        "name": user["name"],
        "email": user["email"],
        "password": user["password"],
        "institution_id": user["institution_id"],
        "created_at": user["created_at"]
    }


def institution_list_serial(institutions)->list:
    return [institution_serial(institution) for institution in institutions]

def user_list_serial(users)->list:
    return [user_serial(user) for user in users]