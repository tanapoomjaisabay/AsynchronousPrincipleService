# AsynchronousPrincipleService

A demonstration project illustrating different asynchronous execution patterns between two distributed .NET 9 services: `ServiceA` and `ServiceB`.

---

## 🎯 Project Purpose

The objective of this project is to demonstrate **three distinct robot creation patterns** through asynchronous communication between two independent services:

1. **CreateRobotWithSequence**  
   ServiceA calls ServiceB sequentially. Each call to ServiceB must complete before proceeding to the next operation.

2. **CreateRobotWithParallel**  
   ServiceA initiates multiple asynchronous calls to ServiceB without awaiting them immediately. After all calls have been issued, ServiceA then awaits the responses collectively before proceeding.

3. **ScheduleRobotCreation**  
   ServiceA invokes ServiceB in a fire-and-forget manner. It does not await any response from ServiceB and immediately continues its own workflow, returning a response to the client once its local tasks are complete.

These scenarios provide practical insights into how different asynchronous strategies impact the responsiveness, scalability, and resource management of microservice-based systems.

---

## 🛠 Technology Stack

- .NET 9 (ASP.NET Core Web API)
- C# (async/await programming model)
- Docker & Docker Compose (for local deployment)
- Linux-based Docker images
- HTTPClient for service-to-service communication

---

## 📦 Project Structure Overview

```bash
AsynchronousPrincipleService/
├── ServiceA/
│   └── src/
│       └── ServiceA/
│           ├── Controllers/
│           ├── Services/
│           ├── Program.cs
│           └── Dockerfile
├── ServiceB/
│   └── src/
│       └── ServiceB/
│           ├── Controllers/
│           ├── Services/
│           ├── Program.cs
│           └── Dockerfile
├── Infrastructure/
│   └── async-principle-service.
│       ├── docker-compose.yml
```

---

## 📡 API Endpoints (ServiceA)

| Scenario                   | Method | Endpoint                                  | Description |
|-----------------------------|--------|-------------------------------------------|-------------|
| CreateRobotWithSequence     | POST   | `/api/robot/create-with-sequence`         | Sequential execution |
| CreateRobotWithParallel     | POST   | `/api/robot/create-with-parallel`         | Parallel execution |
| ScheduleRobotCreation       | POST   | `/api/robot/schedule-creation`            | Fire-and-forget execution |

---

## 🧪 Example Request & Response

### 1. GET `/api/robotfactory/createrobotwithsequence`

#### Request Payload
```url
http://localhost:5006/api/robotfactory/createrobotwithsequence?colour=Red
```

#### Expected Response
```json
{
  "result": "Request took 25 s",
  "robotDetail": "Head is Red, Body is Red, Arm is Red, Arm is Red"
}
```

---

### 2. GET `/api/robotfactory/createrobotwithparallel`

#### Request Payload
```url
http://localhost:5006/api/robotfactory/createrobotwithparallel?colour=Green
```

#### Expected Response
```json
{
  "result": "Request took 10 s",
  "robotDetail": "Head is Green, Body is Green, Arm is Green, Arm is Green"
}
```

---

### 3. GET `/api/robotfactory/schedulerobotcreation`

#### Request Payload
```url
http://localhost:5006/api/robotfactory/schedulerobotcreation?colour=Blue
```

#### Expected Response
```json
{
  "result": "Request took 2 s",
  "robotDetail": "Add robot in queue."
}
```

---

## 📦 Docker Deployment Instructions

### Build and Run

```bash
docker-compose up -d
```

### Services Accessible at:
- ServiceA: [http://localhost:5006](http://localhost:5006)
- ServiceB: [http://localhost:5007](http://localhost:5007)

---
