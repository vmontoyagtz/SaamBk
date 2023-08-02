# Use an official Python runtime based on Alpine as a parent image
FROM python:3.9-alpine

# Set the working directory
WORKDIR /app

# Copy the requirements.txt file into the container
COPY requirements.txt .

# Install any needed packages specified in requirements.txt
RUN apk add --no-cache --virtual .build-deps \
        gcc \
        musl-dev \
    && pip install --trusted-host pypi.python.org -r requirements.txt \
    && apk del .build-deps

# Copy the rest of the application code
COPY . .

# Make the container's port 8000 available to the outside world
EXPOSE 8000

# Run the application
CMD ["flask", "run"]
