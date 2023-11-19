import React, { useState, useEffect, useRef } from "react";
import { useLocation } from "react-router-dom";
import { useNavigate } from "react-router-dom";

import { variables } from "../../Variables";
import Select from "react-select";

const dropdownStyles = {
  menuPortal: (provided) => ({
    ...provided,
    zIndex: 9999,
  }),
  menu: (provided) => ({
    ...provided,
    width: 300,
  }),
};

function PhrPOS() {
  const navigate = useNavigate();

  //#region logged user data start
  const location = useLocation();
  const userData = location.state && location.state.userData;
  const username = location.state && location.state.userData[0];
  const usertype = location.state && location.state.userData[1];
  const companyname = location.state && location.state.userData[2];
  const url = location.state && location.state.userData[3];
  const pin = location.state && location.state.userData[4];
  const cid = location.state && location.state.userData[5];
  const gid = location.state && location.state.userData[6];
  const access = location.state && location.state.userData[7];
  console.log(userData);
  //#endregion logged user data end

  //#region Initial State
  const [loading, setLoading] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [inputCustomerIdValue, setInputCustomerIdValue] = useState("");

  const [customerTypeInfoList, setCustomerTypeInfoList] = useState([null]);
  const [selectedCustomerInfoType, setSelectedCustomerInfoType] =
    useState(null);
  const [selectedCustomerTypeInfoValue, setSelectedCustomerTypeInfoValue] =
    useState(null);

  const [orgNameInfoList, setOrgNameInfoList] = useState([null]);
  const [selectedOrgNameInfo, setSelectedOrgNameInfo] = useState(null);
  const [selectedOrgNameInfoValue, setSelectedOrgNameInfoValue] =
    useState(null);

  const [departmentInfoList, setDepartmentInfoList] = useState([null]);
  const [selectedDepartmentInfo, setSelectedDepartmentInfo] = useState(null);
  const [selectedDepartmentInfoValue, setSelectedDepartmentInfoValue] =
    useState(null);

  const [designationInfoList, setDesignationInfoList] = useState([null]);
  const [selectedDesignationInfo, setSelectedDesignationInfo] = useState(null);
  const [selectedDesignationInfoValue, setSelectedDesignationInfoValue] =
    useState(null);

  const [selectedGenderInfoValue, setSelectedGenderInfoValue] = useState("");
  const [inputMobileNoInfoValue, setInputMobileNoInfoValue] = useState("");
  const [inputAddressInfoValue, setInputAddressInfoValue] = useState("");
  const [inputIdInfoValue, setInputIdInfoValue] = useState("");
  const [inputPassportInfoValue, setInputPassportInfoValue] = useState("");
  const [inputCreditLimitInfoValue, setInputCreditLimitInfoValue] =
    useState(null);
  const [inputNameInfoValue, setInputNameInfoValue] = useState("");
  const [inputEIDInfoValue, setInputEIDInfoValue] = useState("");
  const [inputNIDInfoValue, setInputNIDInfoValue] = useState("");
  const [inputAgeYYYYInfoValue, setInputAgeYYYYInfoValue] = useState(null);
  const [inputAgeMMInfoValue, setInputAgeMMInfoValue] = useState(null);
  const [inputAgeDDInfoValue, setInputAgeDDInfoValue] = useState(null);

  const [selectedBirthDate, setSelectedBirthDate] = useState(null);
  const [selectedMarriageDate, setSelectedMarriageDate] = useState(null);

  const [customerNoOrRegNo, setCustomerNoOrRegNo] = useState(null);
  const [customerIdOrHospitalNo, setCustomerIdOrHospitalNo] = useState("");

  //#endregion Initial State

  useEffect(() => {
    if (!userData) {
      navigate("/");
    }
    setLoading(true);

    const timeoutId = setTimeout(() => {
      setLoading(false);
    }, 400);

    getCustomerTypeInfoList();
    getOrgNameInfoList();
    getDepartmentInfoList();
    getDesignationInfoList();
    return () => clearTimeout(timeoutId);
  }, []);

  //#region Main POS Element
  const handleCustomerIdChange = (event) => {
    setInputCustomerIdValue(event.target.value);
  };

  const handleCustomerIdEnterKeyPress = (e) => {
    debugger;
    if (e.key === "Enter") {
      let customerIdValue = inputCustomerIdValue;
      console.log(customerIdValue);
      alert("Enter Pressed!");
    }
  };

  const onCustomerInfoSubmitClick = async () => {
    debugger;

    if (inputNameInfoValue === "") {
      alert("Please Enter Customer Name!");
      return;
    } else if (
      !selectedCustomerTypeInfoValue ||
      selectedCustomerTypeInfoValue === undefined
    ) {
      alert("Please Select Customer Type!");
      return;
    } else if (!inputIdInfoValue || inputIdInfoValue === "") {
      alert("Please Enter Customer Id!");
      return;
    } else if (!inputMobileNoInfoValue || inputMobileNoInfoValue === "") {
      alert("Please Enter Customer Mobile No.!");
      return;
    } else if (
      !selectedGenderInfoValue ||
      selectedGenderInfoValue === undefined
    ) {
      alert("Please Select Customer Gender!");

      return;
    }

    // debugger;
    // let receivedbyNo = null;
    // if (
    //   !selectedReceivedByValue ||
    //   selectedReceivedByValue === 0 ||
    //   selectedReceivedByValue === undefined ||
    //   selectedReceivedByValue === ""
    // ) {
    //   receivedbyNo = null;
    // } else {
    //   receivedbyNo = selectedReceivedByValue;
    // }

    // debugger;
    // let orderId = "";

    // if (selectedOrder.label1 === undefined) {
    //   orderId = selectedOrder[0].label1;
    // } else {
    //   orderId = selectedOrder.label1;
    // }

    // const calculatedTotalAmount = orderItemList.reduce(
    //   (total, orderItem) => total + (parseFloat(orderItem.TOTAL_AMOUNT) || 0),
    //   0
    // );
    // setTotalAmount(calculatedTotalAmount.toFixed(4));

    // const calculatedTotalVat = orderItemList.reduce(
    //   (total, orderItem) => total + (parseFloat(orderItem.VAT_AMT) || 0),
    //   0
    // );
    // setTotalVat(calculatedTotalVat.toFixed(4));

    // const calculatedTotalDiscount = orderItemList.reduce(
    //   (total, orderItem) => total + (parseFloat(orderItem.DISCOUNT_AMT) || 0),
    //   0
    // );
    // debugger;
    // setTotalDiscount(calculatedTotalDiscount.toFixed(4));

    // let netAmount =
    //   calculatedTotalAmount + calculatedTotalVat - calculatedTotalDiscount;
    // setNetAmount(Math.round(netAmount * 10000) / 10000);

    await fetch(variables.API_URL + "PhrBilling/CustomerInfoSave", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },

      body: JSON.stringify({
        PatientTypeNo: selectedCustomerTypeInfoValue,
        CustomerName: inputNameInfoValue,
        GenderValue: selectedGenderInfoValue,
        PhoneMobile: inputMobileNoInfoValue,
        Address: inputAddressInfoValue,
        EmployeeId: inputIdInfoValue,
        OrganizationNo: selectedOrgNameInfoValue,
        DesignationNo: selectedDesignationInfoValue,

        DepartmentNo: selectedDepartmentInfoValue,
        NationalId: inputNIDInfoValue,
        PassportNo: inputPassportInfoValue,
        AgeYYY: inputAgeYYYYInfoValue,
        AgeMM: inputAgeMMInfoValue,
        AgeDD: inputAgeDDInfoValue,
        BirthDate: selectedBirthDate,
        MarriageDate: selectedMarriageDate,
        CreditLimit: inputCreditLimitInfoValue,

        entryby: pin,
        cid: cid,
        gid: gid,
        Entryip: url,
      }),
    })
      .then((response) => response.json())
      .then((actualData) => {
        debugger;
        const dataArray = JSON.parse(actualData);

        const data1 = dataArray[0];
        const data2 = dataArray[1];
        const data3 = dataArray[2];
        const data4 = dataArray[3];

        if (data4 === "0") {
          if (
            data3 ===
            "ORA-00001: unique constraint (MEDIKLAUD_ASTER.REGISTRATIONMASTER_U03) violated"
          ) {
            alert(
              "Your entered Customer Id is already used for another user, try different one."
            );
          } else {
            alert(data3);
          }
        } else {
          setCustomerNoOrRegNo(data1);
          setCustomerIdOrHospitalNo(data2);
          alert(data3);
        }
      });
  };

  //#endregion Main POS Element

  //#region Customer Info Modal
  const handleButtonClick = () => {
    // Show the modal
    setShowModal(true);
  };

  const hideModal = () => {
    setShowModal(false);
  };

  const handleMobileNoInfoChange = (e) => {
    setInputMobileNoInfoValue(e.target.value);
  };

  const handleAddressInfoChange = (e) => {
    setInputAddressInfoValue(e.target.value);
  };

  const handleIdInfoChange = (e) => {
    setInputIdInfoValue(e.target.value);
  };

  const handlePassportInfoChange = (e) => {
    setInputPassportInfoValue(e.target.value);
  };

  const handleCreditLimitInfoChange = (e) => {
    setInputCreditLimitInfoValue(e.target.value);
  };

  const handleNameInfoChange = (e) => {
    setInputNameInfoValue(e.target.value);
  };

  const handleEIDInfoChange = (e) => {
    setInputEIDInfoValue(e.target.value);
  };

  const handleNIDInfoChange = (e) => {
    setInputNIDInfoValue(e.target.value);
  };

  const handleAgeYYYYInfoChange = (e) => {
    setInputAgeYYYYInfoValue(e.target.value);
  };

  const handleAgeMMInfoChange = (e) => {
    setInputAgeMMInfoValue(e.target.value);
  };

  const handleAgeDDInfoChange = (e) => {
    setInputAgeDDInfoValue(e.target.value);
  };

  const getCustomerTypeInfoList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrBilling/GetPatientTypeList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setCustomerTypeInfoList(data);
    } catch (error) {
      setCustomerTypeInfoList([]);
    }
  };

  const finalCustomerTypeInfoList = customerTypeInfoList.map(
    (customerType) => ({
      value: customerType?.PAT_TYPE_NO || "",
      label: customerType?.PAT_TYPE_NAME || "",
    })
  );

  const handleCustomerTypeInfoChange = (selectedOption) => {
    setSelectedCustomerInfoType(selectedOption);
    setSelectedCustomerTypeInfoValue(selectedOption.value);
  };

  const getOrgNameInfoList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrBilling/OrganizationList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setOrgNameInfoList(data);
    } catch (error) {
      setOrgNameInfoList([]);
    }
  };

  const finalOrgNameInfoList = orgNameInfoList.map((orgName) => ({
    value: orgName?.ORGANISATION_NO || "",
    label: orgName?.ORGANISATION_NAME || "",
  }));

  const handleOrgNameInfoChange = (selectedOption) => {
    setSelectedOrgNameInfo(selectedOption);
    setSelectedOrgNameInfoValue(selectedOption.value);
  };

  const getDepartmentInfoList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrBilling/DepartmentList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setDepartmentInfoList(data);
    } catch (error) {
      setDepartmentInfoList([]);
    }
  };

  const finalDepartmentInfoList = departmentInfoList.map((department) => ({
    value: department?.BU_NO || "",
    label: department?.BU_NAME || "",
  }));

  const handleDepartmentInfoChange = (selectedOption) => {
    setSelectedDepartmentInfo(selectedOption);
    setSelectedDepartmentInfoValue(selectedOption.value);
  };

  const getDesignationInfoList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrBilling/DesignationList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setDesignationInfoList(data);
    } catch (error) {
      setDesignationInfoList([]);
    }
  };

  const finalDesignationInfoList = designationInfoList.map((designation) => ({
    value: designation?.JOBTITLE_NO || "",
    label: designation?.JOBTITLE_NAME || "",
  }));

  const handleDesignationInfoChange = (selectedOption) => {
    setSelectedDesignationInfo(selectedOption);
    setSelectedDesignationInfoValue(selectedOption.value);
  };

  const handleGenderInfoSelectChange = (event) => {
    const value = event.target.value;
    setSelectedGenderInfoValue(value);
  };

  //#endregion Modal

  return (
    <div>
      {loading ? (
        <div className="loading-overlay">
          <div className="spinner"></div>
        </div>
      ) : (
        <div
          className="maindivpos"
          style={{ paddingLeft: "10px", paddingRight: "10px" }}
        >
          {/* ......................................Customer Card.................................... */}
          <div className="card text-start" style={{ padding: "10px" }}>
            <div className="row">
              <div className="col-md-3">
                <div className="row">
                  <div className="col-4">
                    <label>
                      Cust. Id<span style={{ color: "red" }}>*</span>
                    </label>
                  </div>
                  <div className="col-2">
                    <button
                      class="button-24"
                      style={{ width: "100%", fontWeight: "bold" }}
                      onClick={handleButtonClick}
                    >
                      +
                    </button>
                  </div>
                  <div className="col-6">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      value={inputCustomerIdValue}
                      onChange={handleCustomerIdChange}
                      onKeyPress={handleCustomerIdEnterKeyPress}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>
                      Cust. Name<span style={{ color: "red" }}>*</span>
                    </label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Gender</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      // value={selectedGenderValue}
                      // onChange={handleGenderSelectChange}
                    ></input>
                  </div>
                </div>
              </div>
              <div className="col-md-3">
                <div className="row">
                  <div className="col-4">
                    <label>
                      Mobile No<span style={{ color: "red" }}>*</span>
                    </label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Cust. Address</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Age</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
              </div>
              <div className="col-md-3">
                <div className="row">
                  <div className="col-4">
                    <label>
                      Emp. Id/PF<span style={{ color: "red" }}>*</span>
                    </label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Org. Name</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Dr. Name</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
              </div>
              <div className="col-md-3">
                <div className="row">
                  <div className="col-4">
                    <label>
                      Cust. Type<span style={{ color: "red" }}>*</span>
                    </label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Desig./Dept.</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>

                <div className="row cPaddingTop">
                  <div className="col-4">
                    <label>Dr. Address</label>
                  </div>
                  <div className="col-8">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
              </div>
            </div>
          </div>
          {/* ......................................Customer Card.................................... */}

          {/* ......................................Customer Modal.................................... */}
          <div
            className="modal modal-lg"
            tabIndex="-1"
            role="dialog"
            style={{ display: showModal ? "block" : "none" }}
          >
            <div className="modal-dialog" role="document">
              <div className="modal-content">
                <div
                  className="modal-header"
                  style={{ background: "green", color: "white" }}
                >
                  <h5 className="modal-title">Customer Information</h5>
                  <button
                    type="button"
                    style={{ color: "white" }}
                    className="btn-close"
                    aria-label="Close"
                    onClick={hideModal}
                  ></button>
                </div>
                <div className="modal-body">
                  <div className="row text-start">
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>
                            Cust. Type<span style={{ color: "red" }}>*</span>
                          </label>
                        </div>
                        <div className="col-7">
                          <Select
                            options={finalCustomerTypeInfoList}
                            value={selectedCustomerInfoType}
                            onChange={handleCustomerTypeInfoChange}
                            styles={dropdownStyles}
                          />
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>
                            Mobile No.<span style={{ color: "red" }}>*</span>
                          </label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputMobileNoInfoValue}
                            onChange={(e) => handleMobileNoInfoChange(e)}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>
                            Cust. Id<span style={{ color: "red" }}>*</span>
                          </label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputIdInfoValue}
                            onChange={handleIdInfoChange}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>Cust. Address</label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputAddressInfoValue}
                            onChange={(e) => handleAddressInfoChange(e)}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>Org. Name</label>
                        </div>
                        <div className="col-7">
                          <Select
                            options={finalOrgNameInfoList}
                            value={selectedOrgNameInfo}
                            onChange={handleOrgNameInfoChange}
                            styles={dropdownStyles}
                          />
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>
                            Dept. Name
                          </label>
                        </div>
                        <div className="col-7">
                          <Select
                            options={finalDepartmentInfoList}
                            value={selectedDepartmentInfo}
                            onChange={handleDepartmentInfoChange}
                            styles={dropdownStyles}
                          />
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>Passport</label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputPassportInfoValue}
                            onChange={handlePassportInfoChange}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>Credit Limit</label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputCreditLimitInfoValue}
                            onChange={handleCreditLimitInfoChange}
                          ></input>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-5" style={{ paddingTop: "5px" }}>
                          <label>
                            Gender<span style={{ color: "red" }}>*</span>
                          </label>
                        </div>
                        <div className="col-7">
                          <select
                            className="form-control form-control-sm"
                            id="inputGroupSelect01"
                            value={selectedGenderInfoValue}
                            onChange={handleGenderInfoSelectChange}
                          >
                            <option selected>Choose...</option>
                            <option value={"M"}>Male</option>
                            <option value={"F"}>Female</option>
                            <option value={"O"}>Others</option>
                          </select>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>
                            Cust. Name<span style={{ color: "red" }}>*</span>
                          </label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputNameInfoValue}
                            onChange={handleNameInfoChange}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>EID/PF</label>
                        </div>
                        <div className="col-7">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            value={inputEIDInfoValue}
                            onChange={handleEIDInfoChange}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>
                            Designation
                          </label>
                        </div>
                        <div className="col-7">
                          <Select
                            options={finalDesignationInfoList}
                            value={selectedDesignationInfo}
                            onChange={handleDesignationInfoChange}
                            styles={dropdownStyles}
                          />
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label>Age</label>
                        </div>
                        <div className="col-3">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            placeholder="YYYY"
                            value={inputAgeYYYYInfoValue}
                            onChange={handleAgeYYYYInfoChange}
                          ></input>
                        </div>
                        <div className="col-2">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            placeholder="MM"
                            value={inputAgeMMInfoValue}
                            onChange={handleAgeMMInfoChange}
                          ></input>
                        </div>
                        <div className="col-2">
                          <input
                            type="text"
                            className="form-control form-control-sm"
                            placeholder="DD"
                            value={inputAgeDDInfoValue}
                            onChange={handleAgeDDInfoChange}
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>Birth Day</label>
                        </div>
                        <div className="col-7">
                          <input
                            type="date"
                            className="form-control form-control-sm"
                            placeholder="DD"
                            value={selectedBirthDate}
                            onChange={(e) =>
                              setSelectedBirthDate(e.target.value)
                            }
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>
                            Marriage Day
                          </label>
                        </div>
                        <div className="col-7">
                          <input
                            type="date"
                            className="form-control form-control-sm"
                            placeholder="DD"
                            value={selectedMarriageDate}
                            onChange={(e) =>
                              setSelectedMarriageDate(e.target.value)
                            }
                          ></input>
                        </div>
                      </div>

                      <div className="row cPaddingTop">
                        <div className="col-5">
                          <label style={{ paddingTop: "5px" }}>NID</label>
                        </div>
                        <div className="col-7">
                          <input
                            className="form-control form-control-sm"
                            value={inputNIDInfoValue}
                            onChange={handleNIDInfoChange}
                          ></input>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div className="modal-footer">
                  <button
                    type="button"
                    className="button-24"
                    onClick={onCustomerInfoSubmitClick}
                  >
                    SUBMIT
                  </button>
                </div>
              </div>
            </div>
          </div>
          {/* ......................................Customer Modal.................................... */}

          {/* ......................................Table.................................... */}
          <div className="card text-start" style={{ padding: "10px" }}>
            <div className="row">
              <div className="col-10">
                <div className="row">
                  <div className="col-3">
                    <label>Item Name</label>
                  </div>
                  <div className="col-2">
                    <label>Barcode</label>
                  </div>
                  <div className="col-2">
                    <label>Sales Price</label>
                  </div>
                  <div className="col-1">
                    <label>Stock Qty.</label>
                  </div>
                  <div className="col-1">
                    <label>Item Qty.</label>
                  </div>
                  <div className="col-1">
                    <label style={{ color: "red" }}>Free?</label>
                  </div>
                  <div className="col-2"></div>
                </div>
                <div className="row">
                  <div className="col-3">
                    <Select
                      options={finalCustomerTypeInfoList}
                      value={selectedCustomerInfoType}
                      onChange={handleCustomerTypeInfoChange}
                      styles={dropdownStyles}
                    />
                  </div>
                  <div className="col-2">
                    <input
                      type="text"
                      className="form-control form-control-md"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                  <div className="col-2">
                    <input
                      type="text"
                      className="form-control form-control-md"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                  <div className="col-1">
                    <input
                      type="text"
                      className="form-control form-control-md"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                  <div className="col-1">
                    <input
                      type="text"
                      className="form-control form-control-md"
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                  <div className="col-1" style={{ marginTop: "7px" }}>
                    <input
                      type="checkbox"
                      className="form-check-input"
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                  <div className="col-2 text-start">
                    <button className="button-24" style={{ height: "36px" }}>
                      ADD
                    </button>
                  </div>
                </div>
                <div
                  className="row"
                  style={{
                    background: "#e6e8e6",
                    height: "320px",
                    marginTop: "20px",
                    marginLeft: "0px",
                    borderRadius: "5pt",
                    padding: "10px",
                  }}
                >
                  Table Goes Here
                </div>
              </div>
              <div className="col-2">
                <div
                  style={{
                    border: "1px solid",
                    borderRadius: "5px",
                    padding: "3px",
                  }}
                >
                  <div className="row">
                    <div className="col-5">
                      <label style={{ color: "red" }}>Credit Limit</label>
                    </div>
                    <div className="col-7">
                      <input
                        style={{ paddingTop: "5px" }}
                        type="text"
                        className="form-control form-control-sm"
                        disabled
                        //value={inputApprovedByValue}
                        //onChange={handleApprovedByChange}
                      ></input>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-5">
                      <label style={{ color: "green" }}>Credit Balance</label>
                    </div>
                    <div className="col-7">
                      <input
                        style={{ paddingTop: "5px" }}
                        type="text"
                        className="form-control form-control-sm"
                        disabled
                        //value={inputApprovedByValue}
                        //onChange={handleApprovedByChange}
                      ></input>
                    </div>
                  </div>
                </div>

                <br></br>

                <div className="row">
                  <div className="col-5">
                    <label>Total Amount</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label>VAT</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label>Discount</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label>Net Amount</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label>Adjust</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label>Receivable</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label style={{ color: "green" }}>Paid Amount</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
                <div className="row">
                  <div className="col-5">
                    <label style={{ color: "red" }}>Due Amount</label>
                  </div>
                  <div className="col-7">
                    <input
                      style={{ paddingTop: "5px" }}
                      type="text"
                      className="form-control form-control-sm"
                      disabled
                      //value={inputApprovedByValue}
                      //onChange={handleApprovedByChange}
                    ></input>
                  </div>
                </div>
              </div>
            </div>
          </div>
          {/* ......................................Table.................................... */}
          {/* ......................................Cash.................................... */}
          <div className="card text-start" style={{ padding: "10px" }}>
            <div className="row">
              <div className="col-1">
                <label>Discount Amt.</label>
              </div>
              <div className="col-2">
                <label>Discount Pct.</label>
              </div>
              <div className="col-1">
                <label></label>
              </div>
              <div className="col-2">
                <label>Cash</label>
              </div>
              <div className="col-2">
                <label>Given Amt.</label>
              </div>
              <div className="col-1">
                <label>Cng. Amt.</label>
              </div>
              <div className="col-2">
                <label>Invoice No.</label>
              </div>
              <div className="col-1">
                <label></label>
              </div>
            </div>
            <div className="row">
              <div className="col-1">
                <input
                  type="text"
                  className="form-control form-control-sm"
                  //value={inputApprovedByValue}
                  //onChange={handleApprovedByChange}
                ></input>
              </div>
              <div className="col-2">
                <input
                  type="text"
                  className="form-control form-control-sm"
                  //value={inputApprovedByValue}
                  //onChange={handleApprovedByChange}
                ></input>
              </div>
              <div className="col-1">
                <button
                  class="button-25"
                  style={{width: '100%', fontWeight: "bold" }}
                  //onClick={handleButtonClick}
                >
                  CLEAR
                </button>
              </div>
              <div className="col-2">
                <input
                  type="text"
                  className="form-control form-control-sm"
                  //value={inputApprovedByValue}
                  //onChange={handleApprovedByChange}
                ></input>
              </div>
              <div className="col-2">
                <input
                  type="text"
                  className="form-control form-control-sm"
                  //value={inputApprovedByValue}
                  //onChange={handleApprovedByChange}
                ></input>
              </div>
              <div className="col-1">
                <input
                  type="text"
                  className="form-control form-control-sm"
                  disabled
                  //value={inputApprovedByValue}
                  //onChange={handleApprovedByChange}
                ></input>
              </div>
              <div className="col-2">
                <input
                  type="text"
                  className="form-control form-control-sm"
                  disabled
                  //value={inputApprovedByValue}
                  //onChange={handleApprovedByChange}
                ></input>
              </div>
              <div className="col-1">
                <button
                  class="button-24"
                  style={{ width: "100%", fontWeight: "bold" }}
                  //onClick={handleButtonClick}
                >
                  RE-PRINT
                </button>
              </div>
            </div>
          </div>
          {/* ......................................Cash.................................... */}
        </div>
      )}
    </div>
  );
}

export default PhrPOS;
