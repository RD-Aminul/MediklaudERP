// import React from "react";
import React, { useState, useEffect, useRef } from "react";
import Select from "react-select";
import { useLocation } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { variables } from "../../Variables";

const customStyles2 = {
    menuPortal: (provided) => ({
        ...provided,
        zIndex: 9999,
    }),
    menu: (provided) => ({
        ...provided,
        width: 300,
    }),
};
const customStyles3 = {
    menuPortal: (provided) => ({
        ...provided,
        zIndex: 9999,
    }),
    menu: (provided) => ({
        ...provided,
        width: 950,
    }),
};

function PurchaseRequisition() {
    //---------------------------------------------------------------------------------------------------------------

    const navigate = useNavigate();

    //logged user data start
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
    //logged user data end

    //--------------------------------------------For Entry In button NEW-------------------------------------------------------------------

    //For Notes TextBox  

    const [notes, setNotes] = useState("");

    const handleNotes = (e) => {
        setNotes(e.value);
    }

    //For Required Type fixed dropdown value

    const [requiredType, setRequiredType] = useState([]);

    const handleReqTypeChange = (e) => {
        setRequiredType(e.value);
    }


    //For Reorder Below checkbox
    const [isChecked, setIsChecked] = useState(false);

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
    };


    //---------------------------------------------------------For Entry In button NEW------------------------------------------------------


    const toggleListVisibility = () => {
        setLoading(true);
        setIsListVisible(!isListVisible);
        setIsEntryVisible(false);
        setIsEditVisible(false);
        setLoading(false);
    };

    const toggleEntryVisibility = () => {
        handelNewClear();
        setLoading(true);
        setIsEntryVisible(!isEntryVisible);
        setIsListVisible(false);
        setIsEditVisible(false);
        setLoading(false);
    };

    const handelNewClear = () => {
        setSelectedSupplier("");
        setSelectedFromStore("");
        setSelectedToStore("");

        setItemList([]);
        setSelectedItem(null);

        setNotes("");
        setRequiredType(null);
        setIsChecked(false);

    }

    const toggleEditVisibility = () => {
        setLoading(true);
        setIsEditVisible(!isEditVisible);
        setIsListVisible(false);
        setIsEntryVisible(false);
        setLoading(false);
    };

    //---------------------------------------------------------------------------------------------------------------



    const [isListVisible, setIsListVisible] = useState(true);
    const [isEntryVisible, setIsEntryVisible] = useState(false);
    const [isEditVisible, setIsEditVisible] = useState(false);

    const [loading, setLoading] = useState(true);

    //---------------------------------------------------------------------------------------------------------------

    useEffect(() => {

        if (!userData) {
            navigate("/");
        }

        setLoading(true);
        GetSerFromStoreList();
        GetSerSupplierList();

        GetFromStoreList();
        GetToStoreList();
        GetSupplierList();

        GetRequisitonList("-1", "-1", "-1", "");
        setLoading(false);

    }, []);

    //---------------------------------------------------------------------------------------------------------------


    // Define a state variable to store All Approved Unapproved Cancel value
    const [selectedTypeValue, setSelectedTypeValue] = useState('-1');

    // Define a handleAllChange function to update the selected value
    const handleTypeSelectChange = (event) => {
        debugger
        setSelectedTypeValue(event.target.value);
        GetRequisitonList(
            event.target.value,
            selectedSerFromStoreValue,
            selectedSerSupplierValue,
            searchInputValue
        );
    };


    //If you want to track the search textBox
    const [searchInputValue, setSearchInputValue] = useState("");

    const handleSearchInputChange = (event) => {
        setSearchInputValue(event.target.value);
        GetRequisitonList(
            selectedTypeValue,
            selectedSerFromStoreValue,
            selectedSerSupplierValue,
            event.target.value
        );
    };


    //-----------------------------------------------------------------------------------------------------------------


    // Define a state variable to store the list of stores from the database

    const [serFromStoreList, setserFromStoreList] = useState([null]);
    const [selectedSerFromStore, setSelectedSerFromStore] = useState(null);
    const [selectedSerFromStoreValue, setSelectedSerFromStoreValue] = useState("-1");

    //For From Store dropdown search
    const handleSerFromStoreChange = (event) => {
        setSelectedSerFromStore(event)
        setSelectedSerFromStoreValue(event.value);
        GetRequisitonList(selectedTypeValue, event.value, selectedSerSupplierValue, searchInputValue);
    }


    const finalserFromStoreList = serFromStoreList.map((serStore) => ({
        value: serStore?.STORE_NO || "",
        label: serStore?.STORE_NAME || "",
    }));


    //For Fetch From store Data From Database
    const GetSerFromStoreList = async () => {

        try {
            let response = await fetch(
                `${variables.API_URL}PhrPurchaseRequisition/GetSrcFormStoreList?GID=${encodeURIComponent(gid)}
                &CID=${encodeURIComponent(cid)}
                &UserNo=${encodeURIComponent(pin)}`,

                { method: "GET" }
            );

            if (!response.ok) {
                throw new Error("Failed to fetch data from the API.");
            }

            let data = await response.json();
            setserFromStoreList(data);
        } catch (error) {
            console.error("Error fetching data:", error);
            setserFromStoreList([]);
        }
    };

    //-----------------------------------------------------------------------------------------------------------------


    // Define a state variable to store the list of stores from the database

    const [serSupplierList, setSerSupplierList] = useState([null]);
    const [selectedSerSupplier, setSelectedSerSupplier] = useState(null);
    const [selectedSerSupplierValue, setSelectedSerSupplierValue] = useState("-1");


    //For Supplier dropdown search
    const handleSerSupplierChange = (event) => {
        setSelectedSerSupplier(event);
        setSelectedSerSupplierValue(event.value)
        GetRequisitonList(selectedTypeValue, selectedSerFromStoreValue, event.value, searchInputValue);
    }


    const finalSerSupplierList = serSupplierList.map((serSupplier) => ({
        value: serSupplier?.SUPPLIER_NO || "",
        label: serSupplier?.SUPPLIER_NAME || "",
    }));

    //For Fetch Supplier Data From Database
    const GetSerSupplierList = async () => {
        try {
            let response = await fetch(
                variables.API_URL +
                `PhrPurchaseRequisition/GetSrcSupplierList?GID=${encodeURIComponent(gid)}&
                 CID=${encodeURIComponent(cid)}`,
                { method: "GET" }
            );

            if (!response.ok) {
                throw new Error("Failed to fetch data from the API.");
            }

            let data = await response.json();
            console.log(data);

            setSerSupplierList(data);
        } catch (error) {
            console.error("Error fetching data:", error);
            setSerSupplierList([]);
        }
    };


    //-----------------------------------------------------------------------------------------------------------------


    // Define a state variable to store the list of stores from the database

    const [FromStoreList, setFromStoreList] = useState([null]);
    const [selectedFromStore, setSelectedFromStore] = useState(null);
    const [selectedFromStoreValue, setSelectedFromStoreValue] = useState("");

    //For From Store dropdown search
    const handleFromStoreChange = (event) => {
        setSelectedFromStore(event)
        setSelectedFromStoreValue(event.value);
        GetRequisitonList(selectedTypeValue, event.value, selectedSerSupplierValue, searchInputValue);
    }


    const finalFromStoreList = FromStoreList.map((fromStore) => ({
        value: fromStore?.STORE_NO || "",
        label: fromStore?.STORE_NAME || "",
    }));

    //For Fetch From store Data From Database
    const GetFromStoreList = async () => {

        try {
            let response = await fetch(
                `${variables.API_URL}PhrPurchaseRequisition/GetFormStoreList?GID=${encodeURIComponent(gid)}
                &CID=${encodeURIComponent(cid)}
                &UserNo=${encodeURIComponent(pin)}`,

                { method: "GET" }
            );

            if (!response.ok) {
                throw new Error("Failed to fetch data from the API.");
            }

            let data = await response.json();
            setFromStoreList(data);
        } catch (error) {
            console.error("Error fetching data:", error);
            setFromStoreList([]);
        }
    };


    //-----------------------------------------------------------------------------------------------------------------


    // Define a state variable to store the list of stores from the database

    const [ToStoreList, setToStoreList] = useState([null]);
    const [selectedToStore, setSelectedToStore] = useState(null);
    const [selectedToStoreValue, setSelectedToStoreValue] = useState("");

    //For To Store dropdown search
    const handleToStoreChange = (event) => {
        setSelectedToStore(event)
        setSelectedToStoreValue(event.value);
        GetRequisitonList(selectedTypeValue, event.value, selectedSerSupplierValue, searchInputValue);
    }


    const finalToStoreList = ToStoreList.map((toStore) => ({
        value: toStore?.STORE_NO || "",
        label: toStore?.STORE_NAME || "",
    }));

    //For Fetch From store Data From Database
    const GetToStoreList = async () => {
        let typeNo = 1
        try {
            let response = await fetch(
                `${variables.API_URL}PhrPurchaseRequisition/GetToStoreList?GID=${encodeURIComponent(gid)}
                &CID=${encodeURIComponent(cid)}
                &TypeNo=${encodeURIComponent(typeNo)}`,

                { method: "GET" }
            );

            if (!response.ok) {
                throw new Error("Failed to fetch data from the API.");
            }

            let data = await response.json();
            setToStoreList(data);
        } catch (error) {
            console.error("Error fetching data:", error);
            setToStoreList([]);
        }
    };


    //-----------------------------------------------------------------------------------------------------------------


    // Define a state variable to store the list of stores from the database

    const [SupplierList, setSupplierList] = useState([null]);
    const [selectedSupplier, setSelectedSupplier] = useState(null);
    const [selectedSupplierValue, setSelectedSupplierValue] = useState("");


    //For Supplier dropdown search
    const handleSupplierChange = (selectedOption) => {
        setSelectedSupplier(selectedOption);
        setSelectedSupplierValue(selectedOption?.value || "");
        GetRequisitonList(selectedTypeValue, selectedSerFromStoreValue, selectedOption.value, searchInputValue);

        // Fetch Item List from the database based on the selected supplier
        if (selectedOption) {
            GetItemList(selectedOption.value);
        }
    }


    const finalSupplierList = SupplierList.map((Supplier) => ({
        value: Supplier?.SUPPLIER_NO || "",
        label: Supplier?.SUPPLIER_NAME || "",
    }));

    //For Fetch Supplier Data From Database
    const GetSupplierList = async () => {
        try {
            let response = await fetch(
                variables.API_URL +
                `PhrPurchaseRequisition/GetSupplierList?GID=${encodeURIComponent(gid)}&
                 CID=${encodeURIComponent(cid)}`,
                { method: "GET" }
            );

            if (!response.ok) {
                throw new Error("Failed to fetch data from the API.");
            }

            let data = await response.json();
            console.log(data);

            setSupplierList(data);
        } catch (error) {
            console.error("Error fetching data:", error);
            setSupplierList([]);
        }
    };


    //-----------------------------------------------------------------------------------------------------------------


    // Define a state variable to store the list of stores from the database

    const [ItemList, setItemList] = useState([null]);
    const [selectedItem, setSelectedItem] = useState(null);
    const [selectedItemValue, setSelectedItemValue] = useState("");

    const finalItemList = ItemList.map((Item) => ({
        value: Item?.ITEM_NO || "",
        label1: Item?.ITEM_NAME || "",
        label2: Item?.UOM_NAME || "",
        label3: Item?.BOX_QTY || "",
        label4: Item?.RE_ORDER_LEVEL || "",
        label5: Item?.SALES_PRICE || "",
        label6: Item?.PURCHASE_PRICE || "",
      }));
      

    //For Item dropdown search
    const handleItemChange = (selectedOption) => {
        setSelectedItem({
            label1: selectedOption.label1,
          });

        // setSelectedItem(selectedOption);
        setSelectedItemValue(selectedOption?.value || "");
        GetRequisitonList(selectedTypeValue, selectedSerFromStoreValue, selectedOption.value, searchInputValue);
    }


   


    //For Fetch Item List Data After Supplier select from database
    const GetItemList = async (supplierNo) => {
        debugger;
        if (supplierNo == "") {
            alert("Select Supplier First");
            return;
        }
        else {
            try {
                let response = await fetch(
                    variables.API_URL +
                    `PhrPurchaseRequisition/GetPhrItemList?GID=${encodeURIComponent(gid)}&
             CID=${encodeURIComponent(cid)}&SupplierNo=${encodeURIComponent(supplierNo)}`,
                    { method: "GET" }
                );

                if (!response.ok) {
                    throw new Error("Failed to fetch data from the API.");
                }

                let data = await response.json();
                console.log(data);

                setItemList(data);
            } catch (error) {
                console.error("Error fetching data:", error);
                setItemList([]);
            }
        }

    };



    //-----------------------------------------------------------------------------------------------------------------


    // Function to clear the input field and selected options

    const handleClear = () => {
        setSearchInputValue("");
        setSelectedTypeValue("-1");
        setSelectedSerFromStore(null);
        setSelectedSerFromStoreValue("-1");
        setSelectedSerSupplier(null);
        setSelectedSerSupplierValue("-1");
        GetRequisitonList("-1", "-1", "-1", "");
    };

    //Grid List 

    const [pharmacyRequisitionList, setpharmacyRequisitionList] = useState([]);


    //For All Grid Items

    // Uncomment and adapt the function to fetch data from your API
    const GetRequisitonList = async (selectedTypeValue, selectedSerFromStoreValue, selectedSerSupplierValue, searchInputValue) => {

        const approvalFlag = selectedTypeValue;
        const storeNo = selectedSerFromStoreValue;
        const toStoredropdownvalue = "";
        const supplierNo = selectedSerSupplierValue;
        const phrTrnIdForSearch = searchInputValue;
        const startDate = "01/01/2020";
        const endDate = "01/01/2024";

        try {
            const response = await fetch(
                `${variables.API_URL}PhrPurchaseRequisition/GetPhrRequsitionList?GID=${encodeURIComponent(gid)}
                &CID=${encodeURIComponent(cid)}&ApproveFlag=${encodeURIComponent(approvalFlag)}&StoreNo=${encodeURIComponent(storeNo)}
                &ToStoreNo=${encodeURIComponent(toStoredropdownvalue)}&SupplierNo=${encodeURIComponent(supplierNo)}
                &PurchaseRequisitionId=${encodeURIComponent(phrTrnIdForSearch)}&StartDate=${encodeURIComponent(startDate)}
                &EndDate=${encodeURIComponent(endDate)}`,
                { method: "GET" }
            );

            if (!response.ok) {
                throw new Error("Failed to fetch data from the API.");
            }

            const data = await response.json();
            setpharmacyRequisitionList(data);
            console.log(data);
        } catch (error) {
            console.error("Error fetching data:", error);
            setpharmacyRequisitionList([]); // Handle error condition appropriately
        }
    };

    //For Pagination

    const [currentPage, setCurrentPage] = useState(1);
    const phrRequisitionPerPage = 10;

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    const startIndex = (currentPage - 1) * phrRequisitionPerPage;
    const endIndex = startIndex + phrRequisitionPerPage;
    const currentPharmacyRequisitionList = pharmacyRequisitionList.slice(startIndex, endIndex);


    return (

        <div className="mainDiv" style={{ padding: "10px" }}>

            {isListVisible && (
                <div className="listView">
                    <div className="card" style={{ padding: "10px" }}>

                        {/* ------------------------------------------------Grid Upper Portion Start--------------------------------------------------------- */}

                        <div className="row text-start">

                            {/* ----------------------------------------------------Type Dropdown (DD) Start----------------------------------------------------- */}
                            <div className="col-2">
                                <div className="row">
                                    <div className="col-4">
                                        <label style={{ paddingTop: "5px" }}>Type</label>
                                    </div>
                                    <div className="col-8">
                                        <select
                                            className="form-control form-control-md"
                                            id="inputGroupSelect01"
                                            value={selectedTypeValue}
                                            onChange={handleTypeSelectChange}
                                        >
                                            <option selected value={-1}>All</option>
                                            <option value={1}>Final Approved</option>
                                            <option value={0}>Unapproved</option>
                                            <option value={2}>Cancelled</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            {/* -------------------------------------------------------Type Dropdown (DD) End-------------------------------------------------- */}


                            {/* --------------------------------------------------------From Ser Store DD Start------------------------------------------------- */}
                            <div className="col-3">
                                <div className="row">
                                    <div className="col-4">
                                        <label>Store</label>
                                    </div>
                                    <div className="col-8">
                                        <Select
                                            options={finalserFromStoreList}
                                            value={selectedSerFromStore}
                                            onChange={handleSerFromStoreChange}
                                            styles={customStyles2}


                                        />
                                    </div>
                                </div>
                            </div>
                            {/* --------------------------------------------------------From Ser Store DD End------------------------------------------------- */}


                            {/* --------------------------------------------------------Supplier Ser DD Start------------------------------------------------- */}
                            <div className="col-3">
                                <div className="row">
                                    <div className="col-4">
                                        <label>Supplier</label>
                                    </div>
                                    <div className="col-8">

                                        <Select
                                            options={finalSerSupplierList}
                                            value={selectedSerSupplier}
                                            onChange={handleSerSupplierChange}
                                            styles={customStyles2}
                                        />

                                    </div>
                                </div>
                            </div>
                            {/* ---------------------------------------------------------Supplier Ser DD End------------------------------------------------ */}


                            {/* ---------------------------------------------------------Search Text Box Start------------------------------------------------ */}
                            <div className="col-2">
                                <div className="row">
                                    <div className="col-4">
                                        <label>Search</label>
                                    </div>
                                    <div className="col-8">
                                        <input
                                            type="text"
                                            placeholder="Seach by Requisition No"
                                            className="form-control form-control-md"
                                            value={searchInputValue}
                                            onChange={handleSearchInputChange}
                                        ></input>
                                    </div>
                                </div>
                            </div>
                            {/* ---------------------------------------------------------Search Text Box End------------------------------------------------ */}


                            {/* ----------------------------------------------------------Button Clear&New Start----------------------------------------------- */}
                            <div className="col-2 text-end">
                                <button class="button-25" onClick={handleClear}>CLEAR</button>
                                &nbsp;&nbsp;
                                <button class="button-24" onClick={toggleEntryVisibility}>
                                    NEW
                                </button>
                            </div>
                            {/* ----------------------------------------------------------Button Clear&New End----------------------------------------------- */}

                        </div>

                        {/* ------------------------------------------------Grid Upper Portion End--------------------------------------------------------- */}

                    </div>
                    <div className="card" style={{ padding: "10px" }}>
                        <table className="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th className="text-start My-Tag-Font-Size">Requisition No</th>
                                    <th className="text-start My-Tag-Font-Size">Req. Date</th>
                                    <th className="text-start My-Tag-Font-Size">Store Name</th>
                                    <th className="text-start My-Tag-Font-Size">Supplier Name</th>
                                    <th className="text-start My-Tag-Font-Size">Req.Type</th>
                                    <th className="text-start My-Tag-Font-Size">Status</th>
                                    <th className="text-start My-Tag-Font-Size">Approved By</th>
                                    <th className="text-start My-Tag-Font-Size">Approve Date</th>
                                    <th className="text-start My-Tag-Font-Size">User</th>
                                    <th className="text-start My-Tag-Font-Size">Total Amt.</th>
                                    <th className="text-start My-Tag-Font-Size">#</th>
                                </tr>
                            </thead>
                            {/* Uncomment this part to render the grid data */}
                            <tbody>
                                {currentPharmacyRequisitionList.map((PhrRequisition) => (
                                    <tr key={PhrRequisition.PHR_TRN_NO} className="My-Tag-Font-Size">
                                        <td className="text-start">{PhrRequisition.PHR_PUR_REQ_ID}</td>
                                        <td className="text-start">{PhrRequisition.PUR_REQ_DATETIME}</td>
                                        <td className="text-start">{PhrRequisition.STORE_NAME}</td>
                                        <td className="text-start">{PhrRequisition.SUPPLIER_NAME}</td>
                                        <td className="text-start">{PhrRequisition.REQ_STATUS_NAME}</td>
                                        <td className="text-start">{PhrRequisition.TRN_STATUS}</td>
                                        <td className="text-start">{PhrRequisition.APPROVE_BY_NAME}</td>
                                        <td className="text-start">{PhrRequisition.APPROVE_DATE}</td>
                                        <td className="text-start">{PhrRequisition.USER_NAME}</td>
                                        <td className="text-start">{PhrRequisition.TOTAL_AMT}</td>

                                        <td className="text-end">
                                            <button
                                                type="button" onClick={toggleEditVisibility}
                                                style={{
                                                    color: "white",
                                                    background: "rgb(255, 0, 0)",
                                                    borderRadius: "3px",
                                                    border: "none",
                                                    fontWeight: "bold",
                                                }}
                                            >
                                                EDIT
                                            </button>
                                        </td>

                                    </tr>
                                ))}
                            </tbody>

                        </table>
                        <nav>
                            <ul className="pagination">
                                {Array.from({ length: Math.ceil(pharmacyRequisitionList.length / phrRequisitionPerPage) }, (_, index) => (
                                    <li key={index} className={`page-item ${currentPage === index + 1 ? 'active' : ''}`}>
                                        <button
                                            className="page-link"
                                            onClick={() => handlePageChange(index + 1)}
                                        >
                                            {index + 1}
                                        </button>
                                    </li>
                                ))}
                            </ul>
                        </nav>
                    </div>
                </div>
            )}

            {/* --------------------------------------------------------Btn NEW Start------------------------------------------------- */}
            {/* --------------------------------------------------------Btn NEW Start------------------------------------------------- */}



            {isEntryVisible && (
                <div className="entryView">
                    <div className="card text-start" style={{ margin: "20px", padding: "10px" }}>

                        <div className="row">

                            <div className="col-md-3">

                                {/* --------------------------------------------------------From  Store DD Start------------------------------------------------- */}
                                <div className="row">
                                    <div className="col-3">
                                        <label>Store</label>
                                    </div>
                                    <div className="col-9">
                                        <Select
                                            options={finalFromStoreList}
                                            value={selectedFromStore}
                                            onChange={handleFromStoreChange}
                                            styles={customStyles2}


                                        />
                                    </div>
                                </div>

                                {/* --------------------------------------------------------From  Store DD End------------------------------------------------- */}

                                {/* --------------------------------------------------------To  Store DD Start------------------------------------------------- */}
                                <div className="row">
                                    <div className="col-3">
                                        <label> ToStore</label>
                                    </div>
                                    <div className="col-9">
                                        <Select
                                            options={finalToStoreList}
                                            value={selectedToStore}
                                            onChange={handleToStoreChange}
                                            styles={customStyles2}


                                        />
                                    </div>
                                </div>

                                {/* --------------------------------------------------------To  Store DD End------------------------------------------------- */}


                                {/* --------------------------------------------------------Supplier DD Start------------------------------------------------- */}

                                <div className="row cPaddingTop">
                                    <div className="col-3">
                                        <label>Supplier</label>
                                    </div>
                                    <div className="col-6">

                                        <Select
                                            options={finalSupplierList}
                                            value={selectedSupplier}
                                            onChange={handleSupplierChange}
                                            styles={customStyles2}
                                        />

                                    </div>
                                    <div className="col-3 text-end">
                                        <button class="button-24">ADD</button>
                                    </div>
                                </div>

                                {/* ---------------------------------------------------------Supplier DD End------------------------------------------------ */}


                            </div>

                            <div className="col-md-3">
                                <div className="row">
                                    <div className="col-3">
                                        <label>Req.No</label>
                                    </div>
                                    <div className="col-9">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>
                                <div className="row cPaddingTop">
                                    <div className="col-3">
                                        <label>Notes</label>
                                    </div>
                                    <div className="col-9">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            value={notes}
                                            onChange={handleNotes}
                                        ></input>
                                    </div>
                                </div>


                                <div className="row cPaddingTop">
                                    <div className="col-3">
                                        <label>Req.Type</label>
                                    </div>
                                    <div className="col-9">
                                        <select
                                            className="form-control form-control-sm"
                                            id="inputGroupSelect01"
                                            value={requiredType}
                                            onChange={handleReqTypeChange}
                                        >
                                            <option value={1}>Normal</option>
                                            <option value={2}>Urgent</option>
                                            <option value={3}>Others</option>
                                        </select>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-3">
                                <div className="row">
                                    <div className="col-5">
                                        <label>Requisition Date</label>
                                    </div>
                                    <div className="col-7">
                                        <input
                                            type="date"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                                <div className="row cPaddingTop">
                                    <div className="col-5">
                                        <label>User</label>
                                    </div>
                                    <div className="col-7">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        ></input>
                                    </div>
                                </div>

                                <div className="row cPaddingTop">
                                    <div className="col-5">
                                        <label>Reorder Below</label>
                                    </div>
                                    <div className="col-2">
                                        <input
                                            type="checkbox"
                                            className="form-check-input form-control-sm"
                                            checked={isChecked}
                                            onChange={handleCheckboxChange}
                                        />
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-3">
                                <div className="row">
                                    <div className="col-4">
                                        <label>Status</label>
                                    </div>
                                    <div className="col-4">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        ></input>
                                    </div>
                                    <div className="col-4 text-end">
                                        <button class="button-24" onClick={toggleListVisibility}>
                                            LIST
                                        </button>
                                    </div>
                                </div>

                                <div className="row cPaddingTop">
                                    <div className="col-4">
                                        <label>Approved By</label>
                                    </div>
                                    <div className="col-8">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>

                    <div className="card text-start" style={{ margin: "20px", padding: "10px", fontSize: "small" }}>
                        <div className="row">
                            <div className="col-md-2">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Item Name</label>
                                    </div>
                                    <div className="col-12">

                                        <Select
                                            options={finalItemList}
                                            value={selectedItem}
                                            onChange={handleItemChange}
                                            getOptionLabel={
                                                (option) => (
                                                  <div className="row">
                                                    <div className="col-4">{option.label1}</div>
                                                    <div className="col-2">{option.label2}</div>
                                                    <div className="col-2">{option.label3}</div>
                                                    <div className="col-1">{option.label4}</div>
                                                    <div className="col-2">{option.label5}</div>
                                                    <div className="col-1">{option.label6}</div>
                                                  </div>
                                                )
                                              }
                                              getOptionValue={(option) => option.value}
                                            styles={customStyles3}
                                        />

                                    </div>
                                </div>


                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>UOM</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>Pack</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>ROL</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>MRP/pcs</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>PP/pcs</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>QOH</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Cons(Box)</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Cons(pcs)</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Req(Box)</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"

                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label></label>
                                    </div>
                                    <div className="col-12">
                                        <button class="button-25">ADD</button>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>




                    <div className="row" style={{ margin: "20px", padding: "0px", fontSize: "small" }}>
                        <div className="col-4"></div>
                        <div className="col-8 text-end">
                            <button class="button-25">CANCEL</button>
                            &nbsp;&nbsp;
                            <button class="button-25">UNAPPROVE</button>
                            &nbsp;&nbsp;
                            <button class="button-24">APPROVE</button>
                            &nbsp;&nbsp;
                            <button class="button-24">NEW</button>
                            &nbsp;&nbsp;
                            <button class="button-24">SUBMIT</button>
                        </div>
                    </div>

                </div>
            )}

            {/* --------------------------------------------------------Btn NEW End------------------------------------------------- */}

            {isEditVisible && (
                <div className="editView">
                    <div className="card text-start" style={{ margin: "20px", padding: "10px" }}>

                        <div className="row">

                            <div className="col-md-3">

                                {/* --------------------------------------------------------From  Store DD Start------------------------------------------------- */}
                                <div className="row">
                                    <div className="col-3">
                                        <label>Store</label>
                                    </div>
                                    <div className="col-9">
                                        <Select
                                            options={finalFromStoreList}
                                            value={selectedFromStore}
                                            onChange={handleFromStoreChange}
                                            styles={customStyles2}


                                        />
                                    </div>
                                </div>

                                {/* --------------------------------------------------------From  Store DD End------------------------------------------------- */}

                                {/* --------------------------------------------------------To  Store DD Start------------------------------------------------- */}
                                <div className="row">
                                    <div className="col-3">
                                        <label> ToStore</label>
                                    </div>
                                    <div className="col-9">
                                        <Select
                                            options={finalToStoreList}
                                            value={selectedToStore}
                                            onChange={handleToStoreChange}
                                            styles={customStyles2}


                                        />
                                    </div>
                                </div>

                                {/* --------------------------------------------------------To  Store DD End------------------------------------------------- */}


                                {/* --------------------------------------------------------Supplier DD Start------------------------------------------------- */}

                                <div className="row cPaddingTop">
                                    <div className="col-3">
                                        <label>Supplier</label>
                                    </div>
                                    <div className="col-6">

                                        <Select
                                            options={finalSupplierList}
                                            value={selectedSupplier}
                                            onChange={handleSupplierChange}
                                            styles={customStyles2}
                                        />

                                    </div>
                                    <div className="col-sm-3 text-end">
                                        <button class="button-24">ADD</button>
                                    </div>
                                </div>

                                {/* ---------------------------------------------------------Supplier DD End------------------------------------------------ */}


                            </div>

                            <div className="col-md-3">
                                <div className="row">
                                    <div className="col-4">
                                        <label>Req.No</label>
                                    </div>
                                    <div className="col-8">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>
                                <div className="row cPaddingTop">
                                    <div className="col-4">
                                        <label>Notes</label>
                                    </div>
                                    <div className="col-8">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                        ></input>
                                    </div>
                                </div>
                                <div className="row cPaddingTop">
                                    <div className="col-4">
                                        <label>Req.Type</label>
                                    </div>
                                    <div className="col-8">
                                        <select
                                            className="form-control form-control-sm"
                                            id="inputGroupSelect01"
                                        >
                                            <option value={1}>Normal</option>
                                            <option value={2}>Urgent</option>
                                            <option value={3}>Others</option>
                                        </select>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-3">
                                <div className="row">
                                    <div className="col-5">
                                        <label>Requisition Date</label>
                                    </div>
                                    <div className="col-7">
                                        <input
                                            type="date"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                                <div className="row cPaddingTop">
                                    <div className="col-5">
                                        <label>User</label>
                                    </div>
                                    <div className="col-7">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        ></input>
                                    </div>
                                </div>

                                <div className="row cPaddingTop">
                                    <div className="col-5">
                                        <label>Reorder Below</label>
                                    </div>
                                    <div className="col-2">
                                        <div>
                                            <input
                                                type="checkbox"
                                                className="form-check-input form-control-sm"
                                                checked={isChecked}
                                                onChange={handleCheckboxChange}
                                            />

                                        </div>
                                    </div>
                                </div>


                            </div>

                            <div className="col-md-3">
                                <div className="row">
                                    <div className="col-4">
                                        <label>Status</label>
                                    </div>
                                    <div className="col-4">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        ></input>
                                    </div>
                                    <div className="col-4 text-end">
                                        <button class="button-24" onClick={toggleListVisibility}>
                                            LIST
                                        </button>
                                    </div>
                                </div>

                                <div className="row cPaddingTop">
                                    <div className="col-4">
                                        <label>Approved By</label>
                                    </div>
                                    <div className="col-8">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>

                    <div className="card text-start" style={{ margin: "20px", padding: "10px", fontSize: "small" }}>
                        <div className="row">

                            <div className="col-md-2">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Item Name</label>
                                    </div>
                                    <div className="col-12">
                                        <Select
                                            options={finalItemList}
                                            value={selectedItem}
                                            onChange={handleItemChange}
                                            styles={customStyles3}
                                        />

                                    </div>
                                </div>


                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>UOM</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>Pack</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>ROL</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>MRP/pcs</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">

                                <div className="row">
                                    <div className="col-12">
                                        <label>PP/pcs</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm" disabled
                                        ></input>
                                    </div>
                                </div>

                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>QOH</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Cons(Box)</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Cons(pcs)</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"
                                            disabled
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label>Req(Box)</label>
                                    </div>
                                    <div className="col-12">
                                        <input
                                            type="text"
                                            className="form-control form-control-sm"

                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="col-md-1">
                                <div className="row">
                                    <div className="col-12">
                                        <label></label>
                                    </div>
                                    <div className="col-12">
                                        <button class="button-25">ADD</button>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>




                    <div className="row" style={{ margin: "20px", padding: "0px", fontSize: "small" }}>
                        <div className="col-4"></div>
                        <div className="col-8 text-end">
                            <button class="button-25">CANCEL</button>
                            &nbsp;&nbsp;
                            <button class="button-25">UNAPPROVE</button>
                            &nbsp;&nbsp;
                            <button class="button-24">APPROVE</button>
                            &nbsp;&nbsp;
                            <button class="button-24">REPORT</button>
                            &nbsp;&nbsp;
                            <button class="button-24">NEW</button>
                            &nbsp;&nbsp;
                            <button class="button-24">SUBMIT</button>
                        </div>
                    </div>

                </div>
            )}

        </div>
    );

}

export default PurchaseRequisition;