 # Unit Testing vs Integration Testing

| Aspect        | Unit Test           | Integration Test                  |
| ------------- | ------------------- | --------------------------------- |
| Scope         | Single method/class | Multiple components               |
| Dependencies  | Mocked              | Real                              |
| Database      | No                  | Yes                               |
| External APIs | Mocked              | Often real/test instance          |
| Speed         | Very fast           | Slower                            |
| Purpose       | Validate logic      | Validate collaboration            |
| Failure Cause | Bug in code logic   | Communication/configuration issue |

 
## Rule of Thumb
 
- **Unit Test:** "Does this piece of code work?"
 
- **Integration Test:** "Do these pieces of code work together?"



--------------------------------------------------


### Interviewing specifically on Unit Testing and Integration Testing in .NET, the questions vary significantly by level. Below is a practical interview guide with the expected question, strong answer, and what the interviewer is actually looking for.

===================

###  Junior Level (0-2 Years)
+++++++++++++++++

###  Q1: What is Unit Testing?

Good Answer

Unit testing is testing a single unit of code, usually a method or class, in isolation from external dependencies such as databases, APIs, and files.

For unit tests, dependencies are mocked to ensure only the business logic is tested.

Example:

C#
```
public decimal CalculateTax(decimal amount)
{
return amount * 0.15m;
}
```

A unit test would verify that the method returns the correct tax value.

  **Interviewer Checks**
  - Understands isolation
  - Understands business logic validation

### Q2: What is Integration Testing?
Good Answer

Integration testing verifies that multiple components work together correctly.

Examples:
```
API + Database
Service + Repository
Controller + Service
```
Unlike unit testing, integration testing often uses real resources.

**Interviewer Checks**
- Knows the difference from unit tests
- Understands component interaction
### Q3: What is the Arrange-Act-Assert Pattern?
Good Answer

Unit tests are commonly structured into:
```
Plain Text
Arrange
	//Prepare test data
Act
	//Execute the code
Assert
   // Verify the result
```
Example:C#
```
[Fact] 
public void Add_ReturnsCorrectSum()
 { 
// Arrange 
var calculator = new Calculator(); 
// Act 
var result = calculator.Add(2, 3); 
// Assert 
Assert.Equal(5, result); 
} 
```

### Q4: Why should we write unit tests?
Good Answer
- Detect bugs early
- Prevent regressions
- Improve code quality
- Make refactoring safer
- Provide documentation of behavior

##  Mid-Level (2-5 Years)

### Q5: What is Mocking?
Good Answer

Mocking means replacing real dependencies with fake objects during testing.

Example:C#
```
var repositoryMock = new Mock<IUserRepository>();
```

This prevents calls to actual databases or APIs.

### Interviewer Follow-up

Why mock?

Answer:

To isolate the code under test and avoid failures caused by external systems.

##  Q6: What frameworks have you used for unit testing?
Good Answer

Common frameworks:

```
xUnit
NUnit
MSTest
```
For mocking:

Most modern .NET projects use xUnit + Moq.

### Q7: What should NOT be mocked?
Good Answer

Do not mock: 
- Simple POCOs
- Value objects
- Business models

Typically mock: 
- Repositories
- External APIs
- Message queues
- Email providers

### Q8: What is Test Coverage?
Good Answer

Test coverage measures how much code is executed during testing.

Example:
```
80% code coverage
```
means tests execute 80% of application code.

#### Important:

High coverage does not necessarily mean high quality tests.

Strong Senior Answer

Coverage is a metric, not a goal.

### Q9: Difference Between Stub, Fake, Mock?
Good Answer
#### Stub
Returns predefined data.

#### Fake 
Simplified implementation.

Example:C#
```
InMemoryDatabase
```
#### Mock
Verifies behavior and interactions.
```
repositoryMock.Verify(x => x.Save());
```

##  Senior Level (5+ Years)

### Q10: What Makes a Good Unit Test?
Good Answer

A good unit test should be:

- Fast
- Independent
- Repeatable
- Self-validating
- Easy to read
Often referred to as:
```
FIRST Principle
```
- Fast
- Independent
- Repeatable
- Self-Validating
- Timely
### Q11: When Should You Write Integration Tests?
Good Answer

When validating that components interact correctly.

Examples:

- EF Core + SQL Server
- API Endpoint + Authentication
- Service + Repository

Integration tests should focus on realistic workflows.
### Q12: Unit Test vs Integration Test
Expected Answer

| Unit Test                 | Integration Test           |
| ------------------------- | -------------------------- |
| Tests one component       | Tests multiple components  |
| Uses mocks                | Uses real dependencies     |
| Very fast                 | Slower                     |
| Easier to maintain        | More setup required        |
| Focuses on business logic | Focuses on system behavior |

### Q13: What Should Be Covered by Unit Tests?
Good Answer

- Business rules
- Validation logic
- Calculations
- Decision-making code

Example:C#
```
Discount calculation 
Eligibility checks 
Status changes 
```
### Q14: What Should Be Covered by Integration Tests?
Good Answer
- Database operations
- API endpoints
- Authentication
- Authorization
- Middleware
- Message brokers
### Q15: Why Are Unit Tests Faster?
Good Answer

Because they don't involve:

- Network calls
- Databases
- File systems
- Web servers

Everything runs in memory.

### Q16: What Is the Difference Between Mock and InMemory Database?
Good Answer
#### Mock
Fakes repository behavior.

C#
```
var repo = new Mock<IUserRepository>();
```
#### InMemory Database

Runs actual EF Core code.

C#
```
UseInMemoryDatabase()
```

Mocking is closer to unit testing.

InMemory DB is often integration testing.

### Q17: How Do You Test ASP.NET Core APIs?
Good Answer
#### Unit Tests

Test:
```
Services
Validators
Business Logic
```
#### Integration Tests

Test:
```
Controllers
Middleware
Authentication
Database Access
```

using:C#
```
WebApplicationFactory<TProgram>
```
### Q18: What Is WebApplicationFactory?
Good Answer

A Microsoft testing utility for hosting an ASP.NET Core application in memory.

Example:C#
```
public class UserApiTests
: IClassFixture<WebApplicationFactory<Program>>
{
}
```
It allows testing APIs without deploying them.

##   Lead / Architect Level
### Q19: What Testing Strategy Would You Use?
Strong Answer

Testing Pyramid:

```
E2E
/ \
Integration
/ \
Unit Tests
```

- Many Unit Tests
- Some Integration Tests
- Few End-to-End Tests

This provides fast feedback and good reliability.

### Q20: If You Had Limited Time, What Would You Test First?
Strong Answer

Prioritize critical business logic:
```
Payment processing
Order creation 
Authentication 
Authorization 
Billing rules
```

High-risk areas should be tested first.

### Q21: What Common Mistakes Do Developers Make in Unit Testing?
Good Answer
- Testing implementation instead of behavior
- Excessive mocking
- Writing brittle tests
- Testing framework code
- Not testing edge cases
- Using real databases in unit tests

###  Most Frequently Asked Testing Questions
- 1- What is Unit Testing?
- 2- What is Integration Testing?
- 3- Unit Test vs Integration Test?
- 4- What is Mocking?
- 5- What is Moq?
- 6- What is xUnit?
- 7- Arrange-Act-Assert pattern?
- 8- What is Test Coverage?
- 9- What is WebApplicationFactory?
- 10- What should be mocked?
- 11- What is a Fake, Stub, and Mock?
- 12- How do you test EF Core?
- 13- How do you test APIs?
- 14- Why are unit tests important?
- 15- What is the Testing Pyramid?
- 16- How do you test async methods?
- 17- How do you test exceptions?
- 18- How do you verify a mock was called?
- 19- What makes a good unit test?
- 20- When should you choose an integration test instead of a unit test?

These 20 questions cover approximately 80-90% of the testing questions asked in .NET Mid/Senior interviews.

### Common Trick Question
### Should every method have a unit test?
Good Senior Answer

No.

Focus on:

- Business logic
- Complex calculations
- Critical workflows
- Validation rules

Usually don't unit test:

- Simple DTOs
- Auto-properties
- Framework code
- Entity classes without logic

### What is the difference between Setup and Verify?
#### Setup

Defines expected behavior.
```
repository.Setup(x => x.GetById(1))
.Returns(user);
```
#### Verify
Checks that a method was actually called.
```
repository.Verify(x => x.Save(user));
```


#### In .NET, xUnit, NUnit, and MSTest are all unit testing frameworks. They do almost the same job, but each has different strengths

### Quick Comparison

| Feature                    | xUnit             | NUnit         | MSTest                |
| -------------------------- | ----------------- | ------------- | --------------------- |
| Developed by               | .NET community    | NUnit team    | Microsoft             |
| Popularity in new projects | ⭐⭐⭐⭐⭐ Very high   | ⭐⭐⭐⭐ High     | ⭐⭐⭐ Medium            |
| Default for modern .NET    | ✅ Often preferred | ✅ Good choice | ✅ Microsoft ecosystem |
| Test Attribute             | `[Fact]`          | `[Test]`      | `[TestMethod]`        |
| Parameterized Tests        | `[Theory]`        | `[TestCase]`  | `[DataTestMethod]`    |
| Parallel Execution         | Excellent         | Good          | Good                  |
| Learning Curve             | Easy              | Easy          | Very Easy             |

### When to Use xUnit

### Choose xUnit when:

- Starting a new ASP.NET Core or .NET project
- Following modern .NET development practices
- Using dependency injection extensively
- Working in open-source projects
- Wanting better extensibility and cleaner design

Example: C#
```
public class CalculatorTests 
{ 
[Fact] 
public void Add_ReturnsSum() 
{ 
var result = 2 + 3; 
Assert.Equal(5, result); 
} 
}
```
### Advantages
- Most popular in modern .NET projects.
- Used by many Microsoft ASP.NET Core samples.
- Better support for parallel test execution.
- Constructor-based setup instead of special attributes.

####  When to Use NUnit

Choose NUnit when:

- You need advanced testing features.
- Your team already uses NUnit.
- You want powerful parameterized testing.

Example: C#
```
[TestFixture]
public class CalculatorTests 
{ 
[Test] 
public void Add_ReturnsSum() 
{ 
Assert.AreEqual(5, 2 + 3); 
} 
}
```
### Advantages
Rich set of assertions.
Very strong parameterized testing support.
```
[TestCase(2,3,5)] 
[TestCase(5,5,10)] 
public void AddTest(int a, int b, int expected) 
{ 
Assert.AreEqual(expected, a + b); 
}
```
#### When to Use MSTest

Choose MSTest when:

- Working in an enterprise environment where Microsoft standards are preferred.
- Maintaining older Visual Studio projects.
- Your organization already uses MSTest templates and pipelines.
- You want a framework officially maintained by Microsoft.

Example: C#
```
[TestClass] 
public class CalculatorTests 
{ 
[TestMethod] 
public void Add_ReturnsSum() 
{ 
Assert.AreEqual(5, 2 + 3); 
} 
}
```
#### Advantages
- Built directly into Visual Studio tooling.
- Easy integration with Azure DevOps.
- Familiar for teams coming from older .NET Framework projects.

####  What I Recommend as a Senior .NET Developer New .NET 6/7/8/9 Project

✅ Use xUnit

Existing Project Already Using NUnit

✅ Stay with NUnit

Enterprise Project Standardized on Microsoft Tools

✅ Use MSTest

Need Heavy Parameterized Testing

✅ Use NUnit

#### Typical Industry Preference Today

xUnit → Most common for new ASP.NET Core projects.

NUnit → Very popular and feature-rich.

MSTest → Common in Microsoft enterprise environments.


#### Rule of thumb: 

For a brand new .NET application, start with xUnit unless your company/team has a standard requiring NUnit or MSTest.