# Bank
<b>Design Patterns Course Project</b> <br/>
I have implemented <i>Command</i>, <i>State</i> and <i>Memento</i> design patterns.

<hr />

The app supports the following commands:
<ul>
    <li>
        Account:
        <ul>
            <li><b>AddAccount <i>first_name</i> <i>last_name</i> <i>balance</i></b></li>
            <li><b>RemoveAccount <i>first_name</i> <i>last_name</i></b></li>
        </ul>
    </li>
    <li>
        Check:
        <ul>
            <li><b>CheckAccount <i>first_name</i> <i>last_name</i></b></li>
            <li><b>CheckAccountType <i>first_name</i> <i>last_name</i></b></li>
            <li><b>CheckBalance <i>first_name</i> <i>last_name</i></b></li>
        </ul>
    </li>
    <li>
        Funds:
        <ul>
            <li><b>DrawFunds <i>first_name</i> <i>last_name</i> <i>amount</i></b></li>
            <li><b>RechargeFunds <i>first_name</i> <i>last_name</i> <i>amount</i></b></li>
        </ul>
    </li>
    <li>
        Loan:
        <ul>
            <li><b>DrawLoan <i>first_name</i> <i>last_name</i> <i>amount</i> <i>years_to_return</i></b></li>
            <li><b>ReturnLoan <i>first_name</i> <i>last_name</i> <i>amount</i></b></li>
        </ul>
    </li>
    <li>
        System:
        <ul>
            <li><b>Shutdown</b></li>
            <li><b>Undo</b></li>
        </ul>
    </li>
</ul>