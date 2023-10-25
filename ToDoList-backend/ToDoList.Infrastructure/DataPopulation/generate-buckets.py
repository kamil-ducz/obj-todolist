import json
import random
from faker import Faker
import string

# Initialize the Faker library
fake = Faker()

# Define the possible values for BucketCategory and BucketColor
bucket_categories = [1, 2, 3]  # Replace with your actual values
bucket_colors = [1, 2, 3, 4, 5, 6]  # Replace with your actual values

# Generate 300 random Bucket records
records = []
records_amount = 300

# Determine the records bool value ratio
num_records_true = int(0.9 * 300)
num_records_false = 300 - num_records_true

# Create a set to store unique nouns
unique_nouns = set()

for i in range(1, num_records_true + 1):
    # Generate a unique English noun
    noun = fake.unique.word().capitalize()
    # Add the noun to the set of unique nouns
    unique_nouns.add(noun)
    
    # Generate a random sentence for the description
    description = fake.sentence(nb_words=5, variable_nb_words=True, ext_word_list=None)
    description = description[:20]  # Limit to 20 characters
    
    record = {
        "Id": i,  # Assign a unique Id value
        "Name": noun,
        "Description": description,
        "BucketCategoryId": random.choice(bucket_categories),
        "BucketColorId": random.choice(bucket_colors),
        "MaxAmountOfTasks": random.randint(1, 15),
        "IsActive": True
    }
    records.append(record)

for i in range(num_records_true + 1, records_amount):
    # Generate a unique English noun
    noun = fake.unique.word().capitalize()
    # Add the noun to the set of unique nouns
    unique_nouns.add(noun)
    
    # Generate a random sentence for the description
    description = fake.sentence(nb_words=5, variable_nb_words=True, ext_word_list=None)
    description = description[:20]  # Limit to 20 characters
    
    record = {
        "Id": i,  # Assign a unique Id value
        "Name": noun,
        "Description": description,
        "BucketCategoryId": random.choice(bucket_categories),
        "BucketColorId": random.choice(bucket_colors),
        "MaxAmountOfTasks": random.randint(1, 15),
        "IsActive": False
    }
    records.append(record)

# Write the records to a JSON file
with open('bucket-population-data.json', 'w') as json_file:
    json.dump(records, json_file, indent=4)

print("JSON file 'bucket-population-data.json' with 300 records, unique English nouns, and descriptions generated.")
