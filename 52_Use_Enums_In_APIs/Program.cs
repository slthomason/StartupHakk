public enum MyEnum {
     @JsonProperty("theFirstValue") THE_FIRST_VALUE,
     @JsonProperty("another_value") ANOTHER_VALUE;
     // another one here, or delete the previous ones
}

public enum AddressType { 
    HOME(true),
    WORK(false),
    OTHER(true);
    private AddressType(boolean businessLogicCondition) {
        this.businessLogicCondition = businessLogicCondition;
    }
    private final boolean businessLogicCondition;
    public boolean getCond() {
        return businessLogicCondition;
    }
};
@Entity
public class Person {
@Enumerated
private AddressType address;
// ...
}
// you can use it after inflation in your code where needed 
Person p1 = service.getPersonById("123");
if(p1.getAddress().getCond()) { /*...*/ }