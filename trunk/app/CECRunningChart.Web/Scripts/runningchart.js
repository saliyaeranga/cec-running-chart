
function setTimePickers() {
    $('.timepick').timepicker({
        showPeriod: true,
        showLeadingZero: true
    });
}

function applyRunningchartValidations() {
    $.validator.addMethod("selectVehicleId", function (value, element) {
        return value > 0;
    }, " *");

    $("#runningchartform").validate({
        rules: {
            BillNumber: {
                required: true,
                maxlength: 10
            },
            BillDate: {
                required: true
            },
            DriverName: {
                required: true,
                maxlength: 200
            },
            SelectedVehicleId: {
                required: true,
                selectVehicleId: true
            },
            DayStartime: {
                required: true
            },
            DayEndTime: {
                required: true
            },
            FuelLeftBegningOfDay: {
                required: true,
                number: true
            },
            FuelLeftEndOfDay: {
                required: true,
                number: true
            },
            FuelUsageOfDay: {
                required: true,
                number: true
            }
        },
        messages: {
            BillNumber: " *",
            BillDate: " *",
            DriverName: " *",
            SelectedVehicleId: " *",
            DayStartime: " *",
            DayEndTime: " *",
            FuelLeftBegningOfDay: {
                required: " *",
                number: " Please enter a valid number"
            },
            FuelLeftEndOfDay: {
                required: " *",
                number: " Please enter a valid number"
            },
            FuelUsageOfDay: {
                required: " *",
                number: " Please enter a valid number"
            }
        }
    });
}

function isLubricantsValid() {
    var isValid = true;
    var lubriCount = $("#LubricantstationsCount").val();
    for (var i = 0; i < lubriCount; i++) {
        document.getElementById("LubricantPumpstationError" + i).style.display = "none";
        document.getElementById("LubricantLubricantError" + i).style.display = "none";
        document.getElementById("LubricantQuantityError" + i).style.display = "none";

        var pumpIndex = document.getElementById("SelectedLubricants[" + i + "].SelectedPumpstationId").selectedIndex;
        var libriIndex = document.getElementById("SelectedLubricants[" + i + "].SelectedLubricantTypeId").selectedIndex;
        var pumpQty = document.getElementById("SelectedLubricants[" + i + "].PumpAmount").value;

        if (pumpIndex <= 0) {
            isValid = false;
            document.getElementById("LubricantPumpstationError" + i).style.display = "inline";
        }
        if (libriIndex <= 0) {
            isValid = false;
            document.getElementById("LubricantLubricantError" + i).style.display = "inline";
        }
        if ($.trim(pumpQty) == "") {
            isValid = false;
            document.getElementById("LubricantQuantityError" + i).style.display = "inline";
        }
    }
    return isValid;
}

function isPumpstationsValid() {
    var isValid = true;
    var pumpstationCount = $("#PumpstationsCount").val();
    for (var i = 0; i < pumpstationCount; i++) {
        document.getElementById("PumpstationPumpstationError" + i).style.display = "none";
        document.getElementById("PumpstationQtyError" + i).style.display = "none";

        var pumpIndex = document.getElementById("SelectedPumpstations[" + i + "].SelectedPumpstationId").selectedIndex;
        var pumpQty = document.getElementById("SelectedPumpstations[" + i + "].PumpAmount").value;

        if (pumpIndex <= 0) {
            isValid = false;
            document.getElementById("PumpstationPumpstationError" + i).style.display = "inline";
        }
        if ($.trim(pumpQty) == "") {
            isValid = false;
            document.getElementById("PumpstationQtyError" + i).style.display = "inline";
        }
    }
    return isValid;
}

function isChartDetailsValid() {
    var isValid = true;
    var itemCount = $("#ChartItemsCount").val();
    for (var i = 0; i < itemCount; i++) {
        document.getElementById("ChartItemStartTimeError" + i).style.display = "none";
        document.getElementById("ChartItemEndTimeError" + i).style.display = "none";
        document.getElementById("ChartItemTimeDiffError" + i).style.display = "none";
        document.getElementById("ChartItemStartMeterError" + i).style.display = "none";
        document.getElementById("ChartItemEndMeterError" + i).style.display = "none";
        document.getElementById("ChartItemMeterDiffError" + i).style.display = "none";
        document.getElementById("ChartItemIdleHrsError" + i).style.display = "none";
        document.getElementById("ChartItemProjectError" + i).style.display = "none";
        document.getElementById("ChartItemProjectMgrError" + i).style.display = "none";
        document.getElementById("ChartItemRentleError" + i).style.display = "none";

        var startTime = document.getElementById("SelectedChartItems[" + i + "].StartTime").value;
        var endTime = document.getElementById("SelectedChartItems[" + i + "].EndTime").value;
        var timeDifference = document.getElementById("SelectedChartItems[" + i + "].TimeDifference").value;
        var startMeter = document.getElementById("SelectedChartItems[" + i + "].StartMeter").value;
        var endMeter = document.getElementById("SelectedChartItems[" + i + "].EndMeter").value;
        var meterDifference = document.getElementById("SelectedChartItems[" + i + "].MeterDifference").value;
        var idleHours = document.getElementById("SelectedChartItems[" + i + "].IdleHours").value;
        var selectedProjectId = document.getElementById("SelectedChartItems[" + i + "].SelectedProjectId").selectedIndex;
        var selectedRentalTypeId = document.getElementById("SelectedChartItems[" + i + "].SelectedRentalTypeId").selectedIndex;
        var pm = document.getElementById("SelectedChartItems[" + i + "].SelectedProjectManager").value;

        if ($.trim(startTime) == "") {
            isValid = false;
            document.getElementById("ChartItemStartTimeError" + i).style.display = "inline";
        }
        if ($.trim(endTime) == "") {
            isValid = false;
            document.getElementById("ChartItemEndTimeError" + i).style.display = "inline";
        }
        if ($.trim(timeDifference) == "") {
            isValid = false;
            document.getElementById("ChartItemTimeDiffError" + i).style.display = "inline";
        }
        if ($.trim(startMeter) == "") {
            isValid = false;
            document.getElementById("ChartItemStartMeterError" + i).style.display = "inline";
        }
        if ($.trim(endMeter) == "") {
            isValid = false;
            document.getElementById("ChartItemEndMeterError" + i).style.display = "inline";
        }
        if ($.trim(meterDifference) == "") {
            isValid = false;
            document.getElementById("ChartItemMeterDiffError" + i).style.display = "inline";
        }
        if ($.trim(idleHours) == "") {
            isValid = false;
            document.getElementById("ChartItemIdleHrsError" + i).style.display = "inline";
        }
        if ($.trim(pm) == "") {
            isValid = false;
            document.getElementById("ChartItemProjectMgrError" + i).style.display = "inline";
        }
        if (selectedProjectId <= 0) {
            isValid = false;
            document.getElementById("ChartItemProjectError" + i).style.display = "inline";
        }
        if (selectedRentalTypeId <= 0) {
            isValid = false;
            document.getElementById("ChartItemRentleError" + i).style.display = "inline";
        }
    }
    return isValid;
}

function PopulateChartRows(isAdding, isRemoving, removingId) {
    var selectedVehicle = $("#SelectedVehicleId").val();
    if (parseInt(selectedVehicle) <= 0) {
        alert("Please Select the Vehicle First!");
        $("#SelectedVehicleId").focus();
        return;
    }

    var formParameters = new Object();
    formParameters.isAddingNewItem = isAdding;
    formParameters.isVehicle = $("#IsVehicle" + selectedVehicle).val();

    var itemCount = $("#ChartItemsCount").val();
    for (var index = 0; index < itemCount; index++) {
        formParameters["[" + index + "].StartTime"] = document.getElementById("SelectedChartItems[" + index + "].StartTime").value;
        formParameters["[" + index + "].EndTime"] = document.getElementById("SelectedChartItems[" + index + "].EndTime").value;
        formParameters["[" + index + "].TimeDifference"] = document.getElementById("SelectedChartItems[" + index + "].TimeDifference").value;
        formParameters["[" + index + "].StartMeter"] = document.getElementById("SelectedChartItems[" + index + "].StartMeter").value;
        formParameters["[" + index + "].EndMeter"] = document.getElementById("SelectedChartItems[" + index + "].EndMeter").value;
        formParameters["[" + index + "].MeterDifference"] = document.getElementById("SelectedChartItems[" + index + "].MeterDifference").value;

        var pumpAmount = document.getElementById("SelectedChartItems[" + index + "].IdleHours").value;
        formParameters["[" + index + "].IdleHours"] = pumpAmount == "" ? "0" : pumpAmount;

        formParameters["[" + index + "].SelectedProjectId"] = document.getElementById("SelectedChartItems[" + index + "].SelectedProjectId").value;
        formParameters["[" + index + "].SelectedProjectManager"] = document.getElementById("SelectedChartItems[" + index + "].SelectedProjectManager").value;
        formParameters["[" + index + "].SelectedRentalTypeId"] = document.getElementById("SelectedChartItems[" + index + "].SelectedRentalTypeId").value;

        // Is removing this item
        if (isRemoving == true && index == removingId) {
            formParameters["[" + index + "].IsRemoving"] = true;
        }
    }

    $.ajaxSetup({ cache: false });
    $.post('/Runningchart/PoulateChartItems', formParameters, function (data) {
        document.getElementById("ChartItems").innerHTML = data;
        setTimePickers();
        setCalculators();
        setProjectManagerFiller();
        if (formParameters.isVehicle == "False") {
            applyTimePickersToMeter();
        }
    });
}

function applyTimePickersToMeter() {
    $('.timemeasure').timepicker({
        showPeriod: true,
        showLeadingZero: true
    });
}

function PopulateLubricantstationRows(isAdding, isRemoving, removingId) {
    var formParameters = new Object();
    formParameters.isAddingNewItem = isAdding;

    var itemCount = document.getElementById("LubricantstationsCount").value;
    for (var i = 0; i < itemCount; i++) {
        formParameters["[" + i + "].SelectedPumpstationId"] = document.getElementById("SelectedLubricants[" + i + "].SelectedPumpstationId").value;
        formParameters["[" + i + "].SelectedLubricantTypeId"] = document.getElementById("SelectedLubricants[" + i + "].SelectedLubricantTypeId").value;
        var pumpAmount = document.getElementById("SelectedLubricants[" + i + "].PumpAmount").value;
        formParameters["[" + i + "].PumpAmount"] = pumpAmount != "" ? pumpAmount : "0";

        // Is removing this item
        if (isRemoving == true && i == removingId) {
            formParameters["[" + i + "].IsRemoving"] = true;
        }
    }

    $.ajaxSetup({ cache: false });
    $.post('/Runningchart/PoulateLubricantItems', formParameters, function (data) {
        document.getElementById("LubricantInfo").innerHTML = data;
    });
}

function PopulatePumpstationRows(isAdding, isRemoving, removingId) {
    var formParameters = new Object();
    formParameters.isAddingNewItem = isAdding;

    var itemCount = document.getElementById("PumpstationsCount").value;
    for (var i = 0; i < itemCount; i++) {
        formParameters["[" + i + "].SelectedPumpstationId"] = document.getElementById("SelectedPumpstations[" + i + "].SelectedPumpstationId").value;
        var pumpAmount = document.getElementById("SelectedPumpstations[" + i + "].PumpAmount").value;
        formParameters["[" + i + "].PumpAmount"] = pumpAmount != "" ? pumpAmount : "0";

        // Is removing this item
        if (isRemoving == true && i == removingId) {
            formParameters["[" + i + "].IsRemoving"] = true;
        }
    }

    $.ajaxSetup({ cache: false });
    $.post('/Runningchart/PoulatePumpstationItems', formParameters, function (data) {
        document.getElementById("PumpStationInfo").innerHTML = data;
    });
}

function setCalculators() {
    $(".calcdiff").change(function () {
        var index = $(this).attr("row");
        calculateTimeDiff(index);
    });
    $(".meterdiff").change(function () {
        var index = $(this).attr("row");
        calculateMetrDiff(index);
    });
}

function calculateTimeDiff(index) {
    var startTime = $.trim(document.getElementById("SelectedChartItems[" + index + "].StartTime").value);
    var endTime = $.trim(document.getElementById("SelectedChartItems[" + index + "].EndTime").value);
    var date = $.trim($("#BillDate").val());

    if (startTime == "" || endTime == "" || date == "") {
        return;
    }

    var startDate = new Date(date + ' ' + startTime);
    var endDate = new Date(date + ' ' + endTime);
    var dateDiff = ((endDate - startDate) / 60000) / 60;
    document.getElementById("SelectedChartItems[" + index + "].TimeDifference").value = dateDiff.toFixed(2);
}

function calculateMetrDiff(index) {
    var startMeter = $.trim(document.getElementById("SelectedChartItems[" + index + "].StartMeter").value);
    var endMeter = $.trim(document.getElementById("SelectedChartItems[" + index + "].EndMeter").value);

    if (startMeter == "" || endMeter == "") {
        return;
    }

    var selectedVehicle = $("#SelectedVehicleId").val();
    var isVehicle = $("#IsVehicle" + selectedVehicle).val();
    if (isVehicle == "True") {
        var meterDiff = parseFloat(endMeter) - parseFloat(startMeter);
        document.getElementById("SelectedChartItems[" + index + "].MeterDifference").value = meterDiff.toFixed(2);
    }
    else {
        var date = $.trim($("#BillDate").val());
        var startDate = new Date(date + ' ' + startMeter);
        var endDate = new Date(date + ' ' + endMeter);
        var dateDiff = ((endDate - startDate) / 60000) / 60;
        document.getElementById("SelectedChartItems[" + index + "].MeterDifference").value = dateDiff.toFixed(2);
    }
}

function setProjectManagerFiller() {
    $(".cecprojects").change(function () {
        var selectedProj = $(this).val();
        var projMgr = selectedProj > 0 ? $("#ProjectManager" + selectedProj).val() : "";
        var index = $(this).attr("row");
        document.getElementById("SelectedChartItems[" + index + "].SelectedProjectManager").value = projMgr;
    });
}