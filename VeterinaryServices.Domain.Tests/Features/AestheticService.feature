Feature: AestheticService state validation

    Scenario: Initial state change to pending
        Given a new aesthetic service
        When input is registered
        Then aesthetic service state should be 0

    Scenario: Current state change to in progress
        Given a new aesthetic service
        When input is registered
        When the aesthetic service is started
        Then aesthetic service state should be 1

    Scenario: Current state change to completed
        Given a new aesthetic service
        When input is registered
        When the aesthetic service is started
        When the aesthetic service is output
        Then aesthetic service state should be 2
        
    Scenario: Current state change to canceled
        Given a new aesthetic service
        When input is registered
        When the aesthetic service is canceled
        Then aesthetic service state should be 3