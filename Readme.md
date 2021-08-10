# Employer Cost Preview
An app written for a job interview with Paylocity!

Things that could have or perhaps should have been done differently if this were an actual production app:
- Probably shouldn't list every single employee in the dropdown on the "dependent" edit/create pages. That could probably stand to be some sort of fancy search box
- Employee list should probably have pages
- You should probably have the ability to select an individual employee on the calculator page to generate a report for
- Might want the ability to label dependents as children or a spouse and constrain people to only one spouse
- It might be necessary to split the data and logic portions of the app into separate projects if they need to be reused elsewhere. Every company I've worked for has done this via NuGet packages but I personally wonder if Git submodules would be easier to work with. I would need to research this more to make an informed decision about that
- The bootstrap 4 grid used in the employee list seems to have inconsistent border thickness between rows. That bugs me and I'd probably try to figure out how to change it