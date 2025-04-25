# DemoDotNet9API &nbsp;![.NET](https://img.shields.io/badge/.NET%209-512BD4?logo=dotnet&logoColor=white) ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-5C2D91?logo=dotnet&logoColor=white)  ![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white) ![GitHub Actions](https://img.shields.io/badge/GitHub%20Actions-2088FF?logo=githubactions&logoColor=white)

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

| Scenario                   | Method | Description |
|-----------------------------|--------|-------------|
| CreateRobotWithSequence     | POST   | Sequential execution |
| CreateRobotWithParallel     | POST   | Parallel execution |
| ScheduleRobotCreation       | POST   | Fire-and-forget execution |

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

## 🚀 Quick Start

```bash
# 1. clone & change directory
git clone https://github.com/tanapoomjaisabay/AsynchronousPrincipleService.git
cd AsynchronousPrincipleService

# 2. spin up MSSQL + both APIs
docker compose -f infrastructure/async-principle-service/docker-compose.yml up -d
```

Visit **Swagger UI**:

* ServiceA → <http://localhost:5006/swagger>
* ServiceB → <http://localhost:5007/swagger>

---

## 🤝 Contributing

PRs are welcome! Feel free to open issues, suggest refactors, or add new features.

---

## 📜 License

Distributed under the **MIT** license. See `LICENSE` for more info.
