# Publish-Subscribe Challenge
## Introduction

The initial introduction to how the base functionalities are implemented can be found in the file [base-functionalities.md](base-functionalities.md).

## Goal
The goal is to test your abilities in your C# skills and the maturity of your coding knowledge. This challenge consists of multiple tasks that are listed below. Take roughly 2 - 3 hours time for solving the tasks below and prepare and present your solutions during the interview. It is no problem if you are not able to solve all tasks during that time.

If something is unclear or undefined, make assumptions and explain them during the interview.

## Task 1: Improvements
Throughout the solving of the next tasks, make notes on what could be improved in general in the code. Regarding any aspect that you might feel has potential to improve which are not already introduced in the task descriptions.

## Task 2: Unit Testing
Currently there aren't any unit tests implemented yet. Your task is to create the most important unit tests for the following methods:
- `AddSubscriberToPublisher` in the class `PublisherService`
- Any method from the controllers

## Task 3: Cascading Delete of a Subscriber
At the moment when a Subscriber is still added to at least one Publisher it cannot be deleted. Implement a functionality that deletes the Subscriber and removes it from every Publisher that it has been subscribed to.

## Task 4: Multiple Output Values per Subscriber
Currently a Subscriber can only store a single value as an output value. Improve the backend in that way that a Subscriber can hold any number of output values.

## Task 5: Customized Exceptions
At the moment only the built-in exception types are used and thus, it can be difficult to return the correct HTTP response in the controller. Improve the error handling in the `PublisherService` to use one or multiple custom exception and catch them respectively in the `PublisherController`.