# Structure of the Microservices Demo Project
This project demonstrates a simple microservices architecture using .NET Core, Redis, and Kubernetes. The structure is designed to showcase how different services can communicate with each other and how they can be deployed in a Kubernetes environment.

# Project Structure
```
microservices-demo/
├── order-service/
│   ├── Dockerfile
│   ├── Program.cs
│   ├── Controllers/
│   │   └── OrdersController.cs
│   ├── Application/
│   │   └── Services/
│   ├── Domain/
│   │   └── Entities/
│   │       └── Order.cs
│   └── Infrastructure/
│       └── Messaging/
│           └── RedisPublisher.cs
├── payment-service/
│   ├── Dockerfile
│   ├── Program.cs
│   ├── Services/
│   │   └── OrderConsumer.cs
│   ├── Application/
│   │   └── Handlers/
│   ├── Domain/
│   │   └── Entities/
│   │       └── PaymentRecord.cs
│   └── Infrastructure/
│       └── Messaging/
│           └── RedisSubscriber.cs
├── shared/
│   └── Messaging/
│       ├── IEventPublisher.cs
│       └── IEventSubscriber.cs
├── k8s/
│   ├── order-deployment.yaml
│   ├── order-service.yaml
│   ├── payment-deployment.yaml
│   ├── payment-service.yaml
│   ├── redis.yaml
│   ├── ingress.yaml
└── docker-compose.yaml
```

- **OrderService**：接收订单请求，写入数据库，通过 Redis 发布消息
- **PaymentService**：后台服务，订阅订单事件并模拟扣款处理
- **Redis/Kafka）**：作为服务间的事件通信桥梁
- **Kubernetes**：用来部署服务并通过 Ingress 进行访问
- **Ingress 域名访问**：比如访问 http://order.local/api/orders 创建订单

# Clean Data Architecture
This project follows the principles of Clean Architecture, separating concerns into different layers:

- **Presentation Layer (Controllers)**: Contains the API controllers and handles HTTP requests.
- **Application Layer (Services)**: Contains the business logic and application services.
- **Domain Layer**: Contains the core entities and domain logic.
- **Infrastructure Layer**: Contains the implementation details, such as database access and messaging.
