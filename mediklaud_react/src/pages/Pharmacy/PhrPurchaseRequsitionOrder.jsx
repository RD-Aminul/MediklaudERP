import React, { useState, useEffect, useRef } from "react";
import { variables } from "../../Variables";
import Select from "react-select";
import { useLocation } from "react-router-dom";
import { useNavigate } from "react-router-dom";


import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';



function PurchaseOrder() {
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

  const [isListVisible, setIsListVisible] = useState(true);
  const [isEntryVisible, setIsEntryVisible] = useState(false);
  const [loading, setLoading] = useState(true)

  const [selectedTypeValue, setSelectedTypeValue] = useState("-1");

  const [serStoreList, setSerStoreList] = useState([null]);
  const [selectedSerStore, setSelectedSerStore] = useState(null);
  const [selectedSerStoreValue, setSelectedSerStoreValue] = useState("-1");

  const [storeListForEntry, setStoreListForEntry] = useState([null]);
  const [selectedStoreForEntry, setSelectedStoreForEntry] = useState([null]);
  const [selectedStoreForEntryValue, setSelectedStoreForEntryValue] = useState("-1");

  const [supplierListForEntry, setSupplierListForEntryView] = useState([null]);
  const [selectedSupplierForEntry, setSelectedSupplierForEntry] = useState([null]);
  const [selectedSupplierForEntryValue, setSelectedSupplierForEntryValue] = useState("-1")

  const [forStoreListEntryView, setforStoreListEntryView] = useState([null]);
  const [selectedforStoreListEntry, setSelectedforStoreListEntry] = useState([null]);
  const [selectedforStoreListEntryValue, setSelectedforStoreListEntryValue] = useState("-1")

  const [selectedPayMode, setSelectedPayMode] = useState("1");

  const [serSupplierList, setSerSupplierList] = useState([null]);
  const [selectedSerSupplier, setSelectedSerSupplier] = useState(null);
  const [selectedSerSupplierValue, setselectedSerSupplierValue] = useState("-1");

  const [searchValue, setSearchValue] = useState("");
  const [transactionList, setTransationList] = useState([]);

  const [currentPage, setCurrentPage] = useState(1);
  const transactionsPerPage = 10;

  const [inputNotesValue, setInputNotesValue] = useState("");
  const [inputOrderNoValue, setInputOrderNoValue] = useState("");
  const [inputOrderDateValue, setInputOrderDateValue] = useState("");
  const [selectedExpectedDate, setSelectedExpectedDate] = useState("");
  const [inputStatusValue, setInputStatusValue] = useState("");
  const [inputApproveValue, setInputApproveValue] = useState("");
  const [inputUserNameValue, setInputUserNameValue] = useState("");

  const [itemListEntryview, setItemListForEntryview] = useState([null]);
  const [selectedItemForEntry, setSelectedItemForEntry] = useState([null]);
  const [selectedItemForEntryValue, setSelectedItemForEntryValue] = useState("-1");

  const [requsitionNoEntry, setRequsitionNoEntry] = useState([null]);
  const [selectedRequsitionNoEntry, setSelectedRequsitionNoEntry] = useState([null]);
  const [selectedRequsitionNoEntryValue, setSelectedRequsitionNoEntryValue] = useState("-1");

  const [supplierQuotFlag, setSupplierQuotFlag] = useState("")






  const [selectedDate, setSelectedDate] = useState(null);
  // const customPlaceholderText = 'Please Select Expected Date..'; // Customize this text as needed









  // ..........................Onchange Or OnClick........................

  const handleTypeSelectChange = (event) => {
    const value = event.target.value;
    setSelectedTypeValue(value);
    getTransationList(value, selectedSerStoreValue, selectedSerSupplierValue, searchValue);
  }

  const handleSerStoreChange = (selectedOption) => {
    setSelectedSerStore(selectedOption);
    setSelectedSerStoreValue(selectedOption.value);
    getTransationList(selectedTypeValue, selectedOption.value, selectedSerSupplierValue, searchValue);
  }

  const handleSerSupplierChange = (selectedOption) => {
    setSelectedSerSupplier(selectedOption);
    setselectedSerSupplierValue(selectedOption.value);
    getTransationList(selectedTypeValue, selectedSerStoreValue, selectedOption.value, searchValue);
  };

  const handleSerChange = (event) => {
    setSearchValue(event.target.value)
    getTransationList(selectedTypeValue, selectedSerStoreValue, selectedSerSupplierValue, event.target.value);
  };

  const handleStoreChange = (selectedOption) => {
    setSelectedStoreForEntry(selectedOption);
    setSelectedStoreForEntryValue(selectedOption.value);
    getRequisitionList(selectedOption.value, selectedSupplierForEntryValue);
  };

  const handleSupplierChange = (selectedOption) => {
    setSelectedSupplierForEntry(selectedOption);
    setSelectedSupplierForEntryValue(selectedOption.value);
    getItemList(selectedOption.value);
    getRequisitionList(selectedforStoreListEntryValue, selectedOption.value);
  };

  const handleForStoreChange = (selectedOption) => {
    setSelectedforStoreListEntry(selectedOption);
    setSelectedforStoreListEntryValue(selectedOption.value);
  };

  const handlePayModeChange = (event) => {
    const value = event.target.value;
    setSelectedPayMode(value);
  }

  const handleNotesChange = (event) => {
    setInputNotesValue(event.target.value);
  };

  const handleItemChange = (selectedOption) => {
    setSelectedItemForEntry({ label: selectedOption.label });
    setSelectedItemForEntryValue(selectedOption.value);
  };

  const handleReqNoChange = (selectedOption) => {
    setSelectedRequsitionNoEntry({ label: selectedOption.label });
    setSelectedRequsitionNoEntryValue(selectedOption.value);
  };

  const clearFilterClick = () => {
    getTransationList("-1", "-1", "-1", "P");
    setSelectedTypeValue("-1");
    setSelectedSerStore(null);
    setSelectedSerStoreValue("-1");
    setSelectedSerSupplier(null);
    setselectedSerSupplierValue("-1");
    setSearchValue("");
  };

  const toggelEntryForm = () => {
    setLoading(true);
    setIsEntryVisible(!isEntryVisible);
    setIsListVisible(false);

    const timeoutId = setTimeout(() => {
      setLoading(false);
    }, 100);
    return () => clearTimeout(timeoutId);
  };

  const toggelListForm = () => {
    setLoading(true);
    getTransationList("-1", "-1", "-1", "P");

    setIsListVisible(!isListVisible);
    setIsEntryVisible(false);

    const timeoutId = setTimeout(() => {
      setLoading(false);
    }, 100);
    return () => clearTimeout(timeoutId);
  };


  // ................GetDataFormAPI............................

  const GetConfigaration = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
        `PurchaseRequsitionOrder/GetConfigaration?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      let suppQuotApplyFlag = data[0].SUPP_QUOT_APPLY_FLAG;
      setSupplierQuotFlag(suppQuotApplyFlag);
    } catch (error) {
      setSupplierQuotFlag("");
    }
  };

  const getSerStoreList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
        `PurchaseRequsitionOrder/GetSerStoreList?GID=${encodeURIComponent(
          gid
        )}&CID=${encodeURIComponent(cid)}&UserNo=${encodeURIComponent(pin)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setSerStoreList(data);
    } catch (error) {
      setSerStoreList([]);
    }
  };

  const getSerSupplierList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
        `PurchaseRequsitionOrder/GetSerSupplierList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      setSerSupplierList(data);
    } catch (error) {
      setSerSupplierList([]);
    }
  };

  const getTransationList = async (serTypeValue, serStoreNo, serSupplierNo, serInputValue) => {
    let ApproveFlag = serTypeValue;
    let StoreNo = serStoreNo;
    let SupplierNo = serSupplierNo;
    let PhrPurOrdId = serInputValue;
    let StartDate = "01/01/2020";
    let EndDate = "01/01/2025";
    try {
      let response = await fetch(
        variables.API_URL + `PurchaseRequsitionOrder/GetTransactionList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}
        &ApproveFlag=${encodeURIComponent(ApproveFlag)}&StoreNo=${encodeURIComponent(StoreNo)}
        &SupplierNo=${encodeURIComponent(SupplierNo)}&PhrPurOrdId=${encodeURIComponent(PhrPurOrdId)}
        &StartDate=${encodeURIComponent(StartDate)}&EndDate=${encodeURIComponent(EndDate)}`,
        { method: "GET" }
      );
      let data = await response.json();
      setTransationList(data);
    }
    catch (error) { }
  };

  const getStoreList = async () => {
    try {
      let response = await fetch(
        variables.API_URL + `PurchaseRequsitionOrder/GetStoreList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}
        &UserNo=${encodeURIComponent(pin)}`,
        { method: "GET" }
      );
      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      setStoreListForEntry(data);
    } catch (error) {
      setStoreListForEntry([])
    }
  };

  const getForStoreList = async () => {
    try {
      let response = await fetch(
        variables.API_URL + `PurchaseRequsitionOrder/GetForStoreList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}
        &UserNo=${encodeURIComponent(pin)}`,
        { method: "GET" }
      );
      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      setforStoreListEntryView(data);
    } catch (error) {
      setforStoreListEntryView([])
    }
  };

  const getSupplierList = async () => {
    try {
      let response = await fetch(
        variables.API_URL + `PurchaseRequsitionOrder/GetSupplierList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );
      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      setSupplierListForEntryView(data);
    } catch (error) {
      setSupplierListForEntryView([])
    }
  };

  const getItemList = async (supplierNo) => {
    try {
      let response = await fetch(
        variables.API_URL + `PurchaseRequsitionOrder/GetItemList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}
        &SupplierNo=${encodeURIComponent(supplierNo)}&SuppQuotFlag=${encodeURIComponent(supplierQuotFlag.toString())}`,
        { method: "GET" }
      );
      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      setItemListForEntryview(data);
    } catch (error) {
      setItemListForEntryview([])
    }
  };

  const getRequisitionList = async (StoreNo, supplierNo) => {
    try {
      debugger
      let response = await fetch(
        variables.API_URL + `PurchaseRequsitionOrder/GetRequisitionList?GID=${encodeURIComponent(gid)}&CID=${encodeURIComponent(cid)}
        &StartDate=${encodeURIComponent("")}&EndDate=${encodeURIComponent("")}&StoreNo=${encodeURIComponent(StoreNo)}
        &SupplierNo=${encodeURIComponent(supplierNo)}`,
        { method: "GET" }
      );
      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      debugger

      setRequsitionNoEntry(data);
    } catch (error) {
      setRequsitionNoEntry([])
    }
  };


  // ................Options.................

  const SearchStoreList = serStoreList.map((serStore) => ({
    value: serStore?.STORE_NO || "",
    label: serStore?.STORE_NAME || "",
  }));

  const SearchSupplierList = serSupplierList.map((serSupplier) => ({
    value: serSupplier?.SUPPLIER_NO || "",
    label: serSupplier?.SUPPLIER_NAME || "",
  }));

  const storeListForEntryview = storeListForEntry.map((store) => ({
    value: store?.STORE_NO || "",
    label: store?.STORE_NAME || "",
  }));

  const supplierListForEntryView = supplierListForEntry.map((supplier) => ({
    value: supplier?.SUPPLIER_NO || "",
    label: supplier?.SUPPLIER_NAME || "",
  }));

  const forStoreListForEntryview = forStoreListEntryView.map((forStore) => ({
    value: forStore?.STORE_NO || "",
    label: forStore?.STORE_NAME || "",
  }));

  const itemListForEntryview = itemListEntryview.map((item) => ({
    value: item?.ITEM_NO || "",
    label: item?.ITEM_NAME || "",
    label1: item?.ITEM_ID || "",
    label2: item?.UOM_NAME || "",
    label3: item?.BOX_QTY || "",
    label4: item?.SALES_PRICE || "",
    label5: item?.PURCHASE_PRICE || "",
  }));

  const requsitionNoEntryview = requsitionNoEntry.map((no) => ({
    value: no?.PHR_PUR_REQ_NO || "",
    label: no?.PHR_PUR_REQ_ID || "",
    label1: no?.PUR_REQ_DATE || "",
    label2: no?.TOTAL_AMT || "",
    label3: no?.SUPPLIER_NAME || "",
    label4: no?.FROM_STORE_NAME || "",
  }));


  const handlePageChange = (page) => {
    setCurrentPage(page);
  };

  const startIndex = (currentPage - 1) * transactionsPerPage;
  const endIndex = startIndex + transactionsPerPage;
  const getTabledata = transactionList.slice(startIndex, endIndex);




  const ddlStyle = {
    menuPortal: (provided) => ({
      ...provided,
      zIndex: 9999,
    }),
    menu: (provided) => ({
      ...provided,
      width: 300,
      fontSize: "10pt",
    }),
    control: (base) => ({
      ...base,
      minHeight: 30,
    }),
    dropdownIndicator: (base) => ({
      ...base,
      padding: 4,
    }),
    clearIndicator: (base) => ({
      ...base,
      padding: 4,
    }),
    multiValue: (base) => ({
      ...base,
      backgroundColor: variables.colorPrimaryLighter,
    }),
    valueContainer: (base) => ({
      ...base,
      padding: "0px 6px",
    }),
    input: (base) => ({
      ...base,
      margin: 0,
      padding: 0,
    }),
  };

  const itemddlStyle = {
    menuPortal: (provided) => ({
      ...provided,
      zIndex: 9999,
    }),
    menu: (provided) => ({
      ...provided,
      width: 800,
      fontSize: "10pt",
    }),
    control: (base) => ({
      ...base,
      minHeight: 30,
    }),
    dropdownIndicator: (base) => ({
      ...base,
      padding: 4,
    }),
    clearIndicator: (base) => ({
      ...base,
      padding: 4,
    }),
    multiValue: (base) => ({
      ...base,
      backgroundColor: variables.colorPrimaryLighter,
    }),
    valueContainer: (base) => ({
      ...base,
      padding: "0px 6px",
    }),
    input: (base) => ({
      ...base,
      margin: 0,
      padding: 0,
    }),
  };

  useEffect(() => {
    if (!userData) {
      navigate("/");
    }
    debugger;
    getTransationList("-1", "-1", "-1", "P");
    GetConfigaration();
    getSerStoreList();
    getSerSupplierList();
    getStoreList();
    getSupplierList();
    getForStoreList();

    const timeoutId = setTimeout(() => {
      setLoading(false);
    }, 100);

    return () => clearTimeout(timeoutId);
  }, []);


  return (
    <div>
      {loading ? (
        <div className="loading-overlay">
          <div className="spinner"></div>
        </div>
      ) : (
        <div>
          {isListVisible && (
            <div className="listView">
              <div className="card" style={{ padding: "10px" }}>
                <div className="card-header">
                  <div className="row text-start">

                    <div className="col-sm-2">
                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ paddingTop: "3px" }}>Type</label>
                        </div>
                        <div className="col-sm-8">
                          <select className="form-control form-control-sm ddl"
                            value={selectedTypeValue}
                            onChange={handleTypeSelectChange}
                            style={ddlStyle}>
                            <option selected value={-1}>All</option>
                            <option value={1}>Approved</option>
                            <option value={0}>Unapproved</option>
                            <option value={2}>Cancelled</option>
                          </select>
                        </div>
                      </div>
                    </div>

                    <div className="col-sm-2">
                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ paddingTop: "3px" }} >Store</label>
                        </div>
                        <div className="col-sm-8">
                          <Select
                            options={SearchStoreList}
                            value={selectedSerStore}
                            onChange={handleSerStoreChange} styles={ddlStyle}
                          ></Select>
                        </div>
                      </div>
                    </div>

                    <div className="col-sm-2">
                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ paddingTop: "3px" }}>Supplier</label>
                        </div>
                        <div className="col-sm-8">
                          <Select
                            options={SearchSupplierList}
                            value={selectedSerSupplier}
                            onChange={handleSerSupplierChange} styles={ddlStyle}
                          ></Select>
                        </div>
                      </div>
                    </div>

                    <div className="col-sm-3">
                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ paddingTop: "3px" }}>Search</label>
                        </div>
                        <div className="col-sm-8">
                          <input type="text" className="form-control form-control-sm" value={searchValue}
                            onChange={handleSerChange} placeholder="Please Search Order No.." />
                        </div>
                      </div>
                    </div>

                    <div className="col-sm-3 text-end">
                      <button className="button-25" onClick={clearFilterClick}>CLEAR </button>
                      &nbsp;&nbsp; &nbsp;&nbsp;
                      <button className="button-24" onClick={toggelEntryForm}>NEW</button>
                    </div>

                  </div>
                </div>
              </div>

              <div className="card" style={{ padding: "10px" }}>
                <table className="table table-striped table-bordered">
                  <thead>
                    <tr>
                      <th className="My-Tag-Font-Size">Order No</th>
                      <th className="My-Tag-Font-Size">Order Date</th>
                      <th className="My-Tag-Font-Size">Store Name</th>
                      <th className="My-Tag-Font-Size">For Store Name</th>
                      <th className="My-Tag-Font-Size">Supplier Name</th>
                      <th className="My-Tag-Font-Size">Status</th>
                      <th className="My-Tag-Font-Size">Approved By</th>
                      <th className="My-Tag-Font-Size">Approve Date</th>
                      <th className="My-Tag-Font-Size"> User</th>
                      <th className="My-Tag-Font-Size">Total Amt.</th>
                      <th className="My-Tag-Font-Size">Req.No</th>
                      <th className="My-Tag-Font-Size"></th>
                    </tr>
                  </thead>
                  <tbody>
                    {getTabledata.map((trn) => (
                      <tr className="My-Tag-Font-Size" key={trn.PHR_PUR_ORD_NO}>
                        <td className="text-start">{trn.PHR_PUR_ORD_ID}</td>
                        <td className="text-start">{trn.PUR_ORD_DATETIME}</td>
                        <td className="text-start">{trn.STORE_NAME}</td>
                        <td className="text-start">{trn.FOR_STORE_NAME}</td>
                        <td className="text-start">{trn.SUPPLIER_NAME}</td>
                        <td className="text-start">{trn.TRN_STATUS}</td>
                        <td className="text-start">{trn.APPROVE_BY_NAME}</td>
                        <td className="text-start">{trn.APPROVE_DATE}</td>
                        <td className="text-start">{trn.USER_NAME}</td>
                        <td className="text-start">{trn.TOTAL_AMT}</td>
                        <td className="text-start">{trn.PHR_PUR_REQ_ID}</td>
                        <td className="text-end">
                          <button id="btnEdit" type="button" >Edit</button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>

                <nav>
                  <ul className="pagination">
                    {Array.from({
                      length: Math.ceil(
                        transactionList.length / transactionsPerPage
                      ),
                    },
                      (_, index) => (
                        <li key={index} className={`page-item ${currentPage === index + 1 ? "active" : ""}`}>
                          <button className="page-link" onClick={() => handlePageChange(index + 1)}>{index + 1}</button>
                        </li>
                      )
                    )}
                  </ul>
                </nav>

              </div>
            </div>
          )}

          {isEntryVisible && (
            <div className="entryView">
              <div className="card" style={{ padding: "10px" }}>
                <div className="card-header">
                  <div className="row text-start">

                    <div className="col-sm-3">
                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>Store <span style={{ color: "#FF0000" }}>*</span></label>
                        </div>
                        <div className="col-sm-7">
                          <Select
                            options={storeListForEntryview}
                            value={selectedStoreForEntry}
                            onChange={handleStoreChange}
                            styles={ddlStyle} />
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "3px" }}>Supplier<span style={{ color: "#FF0000" }}>*</span></label>
                        </div>
                        <div className="col-sm-7">
                          <Select
                            options={supplierListForEntryView}
                            value={selectedSupplierForEntry}
                            onChange={handleSupplierChange}
                            styles={ddlStyle} />
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "3px" }}>Requsition No<span style={{ color: "#FF0000" }}>*</span></label>
                        </div>
                        <div className="col-sm-7">
                          <Select
                            options={requsitionNoEntryview}
                            value={selectedRequsitionNoEntry}
                            onChange={handleReqNoChange}
                            styles={itemddlStyle}
                            getOptionLabel={(option) => (
                              <div className="row">
                                <div className="col-sm-2">{option.label}</div>
                                <div className="col-sm-2">{option.label1}</div>
                                <div className="col-sm-2">{option.label2}</div>
                                <div className="col-sm-3">{option.label3}</div>
                                <div className="col-sm-3">{option.label4}</div>
                              </div>
                            )}
                            getOptionValue={(option) => option.value}
                          />
                        </div>
                      </div>
                    </div>

                    <div className="col-sm-3">
                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>For Store <span style={{ color: "#FF0000" }}>*</span></label>
                        </div>
                        <div className="col-sm-7">
                          <Select
                            options={forStoreListForEntryview}
                            value={selectedforStoreListEntry}
                            onChange={handleForStoreChange}
                            styles={ddlStyle} />
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>Payment Mode</label>
                        </div>
                        <div className="col-sm-7">
                          <select className="form-control form-control-sm"
                            value={selectedPayMode}
                            onChange={handlePayModeChange}
                            style={ddlStyle}>
                            <option selected value={1}>Cash</option>
                            <option value={2}>Credit</option>
                            <option value={3}>After Sales</option>
                            <option value={4}>Others</option>
                          </select>
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>Notes</label>
                        </div>
                        <div className="col-sm-7">
                          <input type="text" className="form-control form-control-sm"
                            value={inputNotesValue}
                            onChange={handleNotesChange} placeholder="Please Enter Notes.." />
                        </div>
                      </div>

                    </div>

                    <div className="col-sm-3">
                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>Order No</label>
                        </div>
                        <div className="col-sm-7">
                          <input type="text" className="form-control form-control-sm"
                            value={inputOrderNoValue}
                            disabled />
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>Order Date</label>
                        </div>
                        <div className="col-sm-7">
                          <input type="text" className="form-control form-control-sm"
                            value={inputOrderDateValue}
                            disabled />
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-5">
                          <label style={{ padding: "5px" }}>Expected Date</label>
                        </div>
                        <div className="col-sm-7">
                          {/* <input type="text" className="form-control form-control-sm"
                            value={selectedExpectedDate}
                            onChange={(e) => setSelectedExpectedDate(e.target.value)} placeholder="Please Select Expected Date.."/> */}
                          <DatePicker
                            id="date"
                            selected={selectedDate}
                            onChange={(date) => setSelectedDate(date)}
                            dateFormat="dd-MMM-yyyy"
                            placeholderText={"Please Select Expected Date.."}
                          />
                        </div>
                      </div>
                    </div>

                    <div className="col-sm-3">
                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ padding: "5px" }}>Status</label>
                        </div>
                        <div className="col-sm-5">
                          <input type="text" className="form-control form-control-sm"
                            value={inputStatusValue}
                            disabled />
                        </div>
                        <div className="col-sm-3 text-end">
                          <button className="button-24" onClick={toggelListForm}>
                            LIST
                          </button>
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ padding: "5px" }}>Approve</label>
                        </div>
                        <div className="col-sm-8">
                          <input type="text" className="form-control form-control-sm"
                            value={inputApproveValue}
                            disabled />
                        </div>
                      </div>

                      <div className="row">
                        <div className="col-sm-4">
                          <label style={{ padding: "5px" }}>User Name</label>
                        </div>
                        <div className="col-sm-8">
                          <input type="text" className="form-control form-control-sm"
                            value={inputUserNameValue}
                            disabled />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <div className="card" style={{ padding: "10px" }}>
                <div className="card-header">
                  <div className="row">

                    <div className="col-sm-2">
                      <div className="row">
                        <div className="col-sm-12">
                          <label style={{ paddingTop: "5px" }}>Item Name</label>
                          <Select
                            className="align"
                            options={itemListForEntryview}
                            value={selectedItemForEntry}
                            onChange={handleItemChange}
                            styles={itemddlStyle}
                            getOptionLabel={(option) => (
                              <div className="row">
                                <div className="col-sm-2">{option.label}</div>
                                <div className="col-sm-2">{option.label1}</div>
                                <div className="col-sm-2">{option.label2}</div>
                                <div className="col-sm-2">{option.label3}</div>
                                <div className="col-sm-2">{option.label4}</div>
                                <div className="col-sm-2">{option.label5}</div>
                              </div>
                            )}
                            getOptionValue={(option) => option.value}
                          />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          )}
        </div>
      )}
    </div>
  )
}

export default PurchaseOrder;
