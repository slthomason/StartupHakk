[ApiController]
public class PersonController : ControllerBase
{
    public ActionResult Post(Person? person)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return BadRequest();
    }

    private bool ValidatePerson(Person? person)
    {
        if (person is null)
            return false;

        if (string.IsNullOrEmpty(person.Name))
            return false;

        if (string.IsNullOrEmpty(person.Address1))
            return false;

        return true;
    }
}