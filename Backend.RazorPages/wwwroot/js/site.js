// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    RefreshData();
    $('#selectUsers').change(OnSelectedUserChanged);
    $('#btnProcess').click(Process);
});


function OnSelectedUserChanged() {
    var userId = $("#selectUsers").val();
    GetBalanceForUser(userId);
}
function Process() {
    var transactionType = $('#transactionType').val();
    var userId = $("#selectUsers").val();
    var amount = $("#amount").val();

    if (transactionType == 0) {
        Deposit(userId, amount);
    } else {
        Withdraw(userId, amount);
    }
}

function GetUsers() {
    $.ajax({
        url: '/?handler=AllUsers'
    })
        .done(function (result) {
            $("#selectUsers").html("");
            $.each(result, function (index, user) {
                $("#selectUsers").append(`<option value="${user.id}">${user.name}</option>`);
            });
            GetBalanceForUser($("#selectUsers").val());
        });
}
function GetBalanceForUser(id) {
    $.ajax({
        url: '/?handler=User',
        data: {
            userId: id
        }
    })
        .done(function (result) {
            $('#userBalance').html("Balance is : $" + result.balance);
        });
}
function Deposit(userId, amount) {
    $.ajax({
        url: '/?handler=Deposit',
        method: "POST",
        data: {
            userId: userId,
            amount: amount
        }
    })
        .done(function (result) {
            console.log((result));
            if (result.result == true) {
                alert("Success!");
            } else {
                alert(result.exceptionMessage);
            }
            RefreshData();
        });
}
function Withdraw(userId, amount) {
    $.ajax({
        url: '/?handler=Withdraw',
        method: "POST",
        data: {
            userId: userId,
            amount: amount
        }
    })
        .done(function (result) {
            if (result.result == true) {
                alert("Success!");
            } else {
                alert(result.exceptionMessage);
            }
            RefreshData();
        });
}
function RefreshData() {
    GetUsers();
    $('#amount').val("");
    $("#transactionType").val(0);
}