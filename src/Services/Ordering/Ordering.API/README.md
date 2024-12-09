### 1. Application Architecture: 
- Clean architecture
- Doman Driven Design
- CQRS
### 2. Pattern and Principle
- Doman Layer
	+ DDD
	+ The doman entity pattern, Entity base classes - Seedwork
	+ Anemic-doman model cs Rick-doman model
	+ The value object pattern
	+ The Aggregate pattern, The Aggregate root or root entity pa
	+ Strong type Ids pattern
	+ Doman events vs integration events
- Infastructure layer
	+ Repository pattern
	+ EF - Code first - migration - Seeding
	+ Value object complex type, EF Aggregate root entities
	+ Entity configuration with modelBuilder - DDD to entity framework code object
	+ Raise & dispatch domain events with EF and MediatR
- Application Layer
	+ CQRS and CQS Pattern
	+ Command and command handler pattern
	+ Mediator pattern, mediatR pipeline behaviours
	+ Fluent validation, Logging cross cutting concerns
- Prepentation Api Layer
	+ Minimal API
	
### 3. Library
- MediatR
- Carter
- Fluent Validation
- Mapster