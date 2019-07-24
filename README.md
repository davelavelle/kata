# kata

With the approach I have take it is difficult to discuss for further refactoring as my opinion of the TDD approach is code what is required at that point.  If further refactoring is required, it depends on the scope of what is required.  If a new discount is added, a test would be written to prove the outcome first.  If this discount is of the same format, the current code should work ok.  If a different discount format was to be added (eg % discount) then again, the tests would be written, then the calculate total method would need to be refactored to suit.
