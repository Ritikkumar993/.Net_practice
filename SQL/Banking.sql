use Banking;

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);



CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20), -- Savings / Current
    OpeningBalance DECIMAL(12,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10), -- Deposit / Withdraw
    Amount DECIMAL(12,2),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

drop table Bonus;


create TABLE Bonus
(
    BonusID INT identity(1,1) PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);


INSERT INTO Customers VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai', '2023-01-10'),
(2, 'Priya Sharma', '9123456789', 'Bangalore', '2023-03-15'),
(3, 'John Peter', '9988776655', 'Hyderabad', '2023-06-20');

INSERT INTO Accounts VALUES
(101, 1, 'SB1001', 'Savings', 20000),
(102, 2, 'SB1002', 'Savings', 15000),
(103, 3, 'SB1003', 'Savings', 30000);


INSERT INTO Transactions VALUES
(1, 101, '2024-01-05', 'Deposit', 30000),
(2, 101, '2024-01-18', 'Withdraw', 5000),
(3, 101, '2024-02-10', 'Deposit', 25000),

(4, 102, '2024-01-07', 'Deposit', 20000),
(5, 102, '2024-01-25', 'Deposit', 35000),
(6, 102, '2024-02-05', 'Withdraw', 10000),

(7, 103, '2024-01-10', 'Deposit', 15000),
(8, 103, '2024-01-20', 'Withdraw', 5000);


-- Q1Total Deposited Amount during the given period

--   Total Withdrawn Amount during the given period

alter proc DateRangeAggregation
    @StartDate Date,
    @EndDate Date,
    @AccountID int
as
begin
    select sum(t.Amount) from Transactions t where TransactionDate between @StartDate and @EndDate Group by AccountID, TransactionType having AccountID=@AccountID and TransactionType='Deposit';
end 

exec DateRangeAggregation '2024-01-07', '2024-02-05', 102;

create proc DateRangeAggregationforWithdraw
    @StartDate Date,
    @EndDate Date,
    @AccountID int
as
begin
    select sum(t.Amount) from Transactions t where TransactionDate between @StartDate and @EndDate Group by AccountID, TransactionType having AccountID=@AccountID and TransactionType='Withdraw';
end 

exec DateRangeAggregationforWithdraw '2024-01-07', '2024-02-05', 102;


-- Q2 If an account’s total deposited amount in a month exceeds ₹50,000 
--- The customer is eligible for a bonus of ₹1,000
-- Identify eligible accounts month-wise

-- Insert bonus records into the Bonus table

-- Bonus should be credited only once per account per month


Insert into Bonus(AccountID,BonusMonth,BonusYear,BonusAmount,CreatedDate)
select 
    t.AccountID as AccountID,
    Month(t.TransactionDate) as BonusMonth,
    Year(t.TransactionDate) as BonusYear,
    1000 as BonusAmount,
    GETDATE() as CreatedDate
from Transactions t
where t.TransactionType='Deposit'
Group By YEAR(t.TransactionDate),
MONTH(t.TransactionDate),
t.AccountID
having Sum(t.Amount)>50000 ;

select * from Bonus;

-- Question 3 – Check Current Balance (Logical Calculation)
-- Current balance is calculated as:

--Opening Balance
--- + Total Deposits
--- - Total Withdrawals
-- + Bonus Amount (if any)
--Task:
---- ==Write a query to display:
 
--- CustomerName

---AccountNumber

-- CurrentBalance

with CurrentBal as(
    select 
    c.CustomerName as CustomerName,
    a.AccountNumber as AccountNumber,
    a.OpeningBalance
    +sum(case when t.TransactionType='Deposit' then  t.Amount else 0 end)
    -sum(case when t.TransactionType='Withdraw' then t.Amount else 0 end)
    +ISNULL(sum(b.BonusAmount),0) as CurrentBalance
    from Customers c 
    inner join Accounts a
    on a.CustomerID=c.CustomerID
    Left join Transactions t
    on t.AccountID=a.AccountID
    Left join Bonus b
    on b.AccountID=a.AccountID
    Group by 
        c.CustomerName,
        a.AccountNumber,
        a.OpeningBalance
)
select * from CurrentBal;




    