import React, { useState, useEffect, useRef } from "react";
import { variables } from "../../Variables";
import Select from "react-select";
import { useLocation } from "react-router-dom";
import { useNavigate } from "react-router-dom";

const customStyles = {
  menuPortal: (provided) => ({
    ...provided,
    zIndex: 9999,
  }),
  menu: (provided) => ({
    ...provided,
    width: 1000,
  }),
};

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

function MRN() {
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

  const [isListVisible, setIsListVisible] = useState(true);
  const [isEntryVisible, setIsEntryVisible] = useState(false);
  const [loading, setLoading] = useState(true);

  const [transactionList, setTransactionList] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const transactionsPerPage = 10;
  const [serarchInputValue, setSerarchInputValue] = useState("");
  const [selectedTypeValue, setSelectedTypeValue] = useState("-1");

  const [serStoreList, setSerStoreList] = useState([null]);
  const [selectedSerStore, setSelectedSerStore] = useState(null);
  const [selectedSerStoreValue, setSelectedSerStoreValue] = useState("-1");

  const [serSupplierList, setSerSupplierList] = useState([null]);
  const [selectedSerSupplier, setSelectedSerSupplier] = useState(null);
  const [selectedSerSupplierValue, setSelectedSerSupplierValue] =
    useState("-1");

  const [storeList, setStoreList] = useState([null]);
  const [selectedStore, setSelectedStore] = useState(null);
  const [selectedStoreValue, setSelectedStoreValue] = useState("");

  const [supplierList, setSupplierList] = useState([null]);
  const [selectedSupplier, setSelectedSupplier] = useState(null);
  const [selectedSupplierValue, setSelectedSupplierValue] = useState("");

  const [orderList, setOrderList] = useState([null]);
  const [selectedOrder, setSelectedOrder] = useState(null);
  const [selectedOrderValue, setSelectedOrderValue] = useState("");

  const [selectedFromDate, setSelectedFromDate] = useState("");
  const [selectedInvoiceDate, setSelectedInvoiceDate] = useState("");
  const [selectedToDate, setSelectedToDate] = useState("");

  const [orderItemList, setOrderItemList] = useState([null]);
  const [inputInvoiceNoValue, setInputInvoiceNoValue] = useState("");

  const [buttonText, setButtonText] = useState("SUBMIT");

  const [phrTrnNo, setPhrTrnNo] = useState("");
  const [phrTrnId, setPhrTrnId] = useState("");

  const [totalAmount, setTotalAmount] = useState(0);
  const [totalVat, setTotalVat] = useState(0);
  const [totalDiscount, setTotalDiscount] = useState(0);
  const [netAmount, setNetAmount] = useState(0);

  const [selectedPayTypeValue, setSelectedPayTypeValue] = useState("");

  const [receivedByList, setReceivedByList] = useState([null]);
  const [selectedReceivedBy, setSelectedReceivedBy] = useState(null);
  const [selectedReceivedByValue, setSelectedReceivedByValue] = useState("");

  const [inputTransNoValue, setInputTransNoValue] = useState("");
  const [inputTransDateValue, setInputTransDateValue] = useState("");
  const [inputUserNameValue, setInputUserNameValue] = useState("");
  const [inputStatusValue, setInputStatusValue] = useState("");
  const [inputApprovedByValue, setInputApprovedByValue] = useState("");
  const [inputApprovedDateValue, setInputApprovedDateValue] = useState("");
  const [txtDiscountAmount, setTxtDiscountAmount] = useState("0");
  const [txtDiscountPct, setTxtDiscountPct] = useState("");

  const [selectedRows, setSelectedRows] = useState([]);

  //---------------------------------------------------------------------------

  const handleRowClick = (itemId) => {
    // Check if the row is already selected
    const isSelected = selectedRows.includes(itemId);

    if (isSelected) {
      // If selected, remove from the array
      setSelectedRows(selectedRows.filter((id) => id !== itemId));
    } else {
      // If not selected, add to the array
      setSelectedRows([...selectedRows, itemId]);
    }
  };

  const handleTxtDiscountAmountChange = (e) => {
    const vatAmount = e.target.value;
    setTxtDiscountAmount(vatAmount);
    setTotalDiscount(vatAmount);
    debugger;
    const calculatedTotalAmount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.TOTAL_VALUES) || 0),
      0
    );

    const updatedOrderItemList = orderItemList.map((orderItem) => {
      let totalAmount = orderItem.TOTAL_AMOUNT;
      let discountAmount = (vatAmount * totalAmount) / calculatedTotalAmount;

      const itemQtyPcs = orderItem.ITEM_QTY || 0;
      const vatAmount2 = orderItem.VAT_AMT || 0;
      const salesPrice = orderItem.SALES_PRICE || 0;

      const unitPrice = (totalAmount + vatAmount2 - discountAmount) / itemQtyPcs;
      let txtVatpct = (vatAmount / calculatedTotalAmount) * 100;

      const gp = salesPrice - unitPrice;
      const gpPct = (gp / salesPrice) * 100;

      //const netTotal = unitPrice * itemQtyPcs;
      setTxtDiscountPct(Math.round(txtVatpct * 1000) / 1000 + "%");
      return {
        ...orderItem,
        DISCOUNT_AMT: Math.round(discountAmount * 10000) / 10000,
        PURCHASE_PRICE: Math.round(unitPrice * 10000) / 10000,
        PROFIT_AMT: gp.toFixed(2),
        PROFIT_PCT: gpPct.toFixed(2) + "%",
        //TOTAL_VALUES: Math.round(netTotal * 10000) / 10000,
      };
    });

    setOrderItemList(updatedOrderItemList);
  };

  const handleTxtDiscountPctChange = (e) => {
    debugger;
    const txtDiscountPct = e.target.value;
    setTxtDiscountPct(txtDiscountPct);
    //setTotalDiscount(txtDiscountPct);

    if (orderItemList !== null) {
      const calculatedTotalAmount = orderItemList.reduce(
        (total, orderItem) => total + (parseFloat(orderItem.TOTAL_VALUES) || 0),
        0
      );

      const updatedOrderItemList = orderItemList.map((orderItem) => {
        let totalAmount = orderItem.TOTAL_AMOUNT;
        let discountAmount =
          (txtDiscountPct * totalAmount) / calculatedTotalAmount;

        const itemQtyPcs = orderItem.ITEM_QTY || 0;
        const vatAmount = orderItem.VAT_AMT || 0;
        const salesPrice = orderItem.SALES_PRICE || 0;
        const unitPrice =
          (totalAmount + vatAmount - discountAmount) / itemQtyPcs;
        //const txtDiscountPct2 = (discountAmount / calculatedTotalAmount) * 100;

        const gp = salesPrice - unitPrice;
        const gpPct = (gp / salesPrice) * 100;
        const netTotal = unitPrice * itemQtyPcs;

        //setTxtDiscountAmount(txtDiscountPct2);
        return {
          ...orderItem,
          DISCOUNT_AMT: Math.round(discountAmount * 10000) / 10000,
          PURCHASE_PRICE: Math.round(unitPrice * 10000) / 10000,
          PROFIT_AMT: gp.toFixed(2),
          PROFIT_PCT: gpPct.toFixed(2) + "%",
          TOTAL_VALUES: netTotal.toFixed(4),
        };
      });

      setOrderItemList(updatedOrderItemList);
    } else {
      setTxtDiscountAmount("");
      alert("No item in table");
    }
  };

  const handleSelectPayTypeChange = (e) => {
    const selectedOption = e.target.value;
    setSelectedPayTypeValue(selectedOption);
  };

  const handleInputInvoiceNoChange = (event) => {
    setInputInvoiceNoValue(event.target.value);
  };

  const handleTransNoChange = (event) => {
    setInputTransNoValue(event.target.value);
  };

  const handleTransDateChange = (event) => {
    setInputTransDateValue(event.target.value);
  };

  const handleUserNameChange = (event) => {
    setInputUserNameValue(event.target.value);
  };

  const handleStatusChange = (event) => {
    setInputStatusValue(event.target.value);
  };

  const handleApprovedByChange = (event) => {
    setInputApprovedByValue(event.target.value);
  };

  const handleApprovedDateChange = (event) => {
    setInputApprovedDateValue(event.target.value);
  };

  const handleBoxQtyChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        const packSize = parseFloat(event.target.value) || 0;
        const receiveQtyBox = item.ITEM_BOX_QTY || 0;
        const bonusQty = item.BONUS_QTY || 0;
        const previousPrice = item.PUR_ORD_PRICE || 0;
        const receiveQtyPcs = packSize * receiveQtyBox;
        const totalAmount = receiveQtyPcs * previousPrice;
        return {
          ...item,
          BOX_QTY: packSize,
          ITEM_QTY: receiveQtyPcs,
          TOTAL_QTY: receiveQtyPcs + bonusQty,
          TOTAL_AMOUNT: Math.round(totalAmount * 10000) / 10000,
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleItemBoxQtyChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        const itemBoxQtyValue = parseFloat(event.target.value) || 0;
        const receiveQtyBox = item.BOX_QTY || 0;
        const bonusQty = item.BONUS_QTY || 0;
        const previousPrice = item.PUR_ORD_PRICE || 0;
        const receiveQtyPcs = itemBoxQtyValue * receiveQtyBox;
        const totalAmount = receiveQtyPcs * previousPrice;
        return {
          ...item,
          ITEM_QTY: receiveQtyPcs,
          ITEM_BOX_QTY: itemBoxQtyValue,
          TOTAL_QTY: receiveQtyPcs + bonusQty,
          TOTAL_AMOUNT: Math.round(totalAmount * 10000) / 10000,
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleBonusQtyChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        debugger;
        const bonusQtyValue = parseFloat(event.target.value) || 0;
        const receiveItemQtyPcs = item.ITEM_QTY || 0;
        const previousPrice = item.PUR_ORD_PRICE || 0;
        const finalTotalQty = bonusQtyValue + receiveItemQtyPcs;
        const totalAmount = receiveItemQtyPcs * previousPrice;
        return {
          ...item,
          BONUS_QTY: bonusQtyValue,
          TOTAL_QTY: finalTotalQty,
          TOTAL_AMOUNT: Math.round(totalAmount * 10000) / 10000,
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleTotalValueChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        const totalValue = parseFloat(event.target.value) || 0;
        const txtDiscountAmount = item.VAT_AMT || 0;
        const discount = item.DISCOUNT_AMT || 0;
        const itemQtyPcs = item.ITEM_QTY || 0;
        const salesPrice = item.SALES_PRICE || 0;
        const unitPrice =
          (totalValue + txtDiscountAmount - discount) / itemQtyPcs;

        const gp = salesPrice - unitPrice;
        const gpPct = (gp / salesPrice) * 100;

        return {
          ...item,
          TOTAL_AMOUNT: Math.round(totalValue * 10000) / 10000,
          PURCHASE_PRICE: Math.round(unitPrice * 10000) / 10000,
          PROFIT_AMT: gp.toFixed(2),
          PROFIT_PCT: gpPct.toFixed(2) + "%",
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleVatChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        debugger;
        const txtDiscountAmount = parseFloat(event.target.value) || 0;
        const totalAmount = item.TOTAL_AMOUNT || 0;
        const discount = item.DISCOUNT_AMT || 0;
        const itemQtyPcs = item.ITEM_QTY || 0;
        const salesPrice = item.SALES_PRICE || 0;
        const unitPrice =
          (totalAmount + txtDiscountAmount - discount) / itemQtyPcs;

        const gp = salesPrice - unitPrice;
        const gpPct = (gp / salesPrice) * 100;

        const netTotal = unitPrice * itemQtyPcs;

        return {
          ...item,
          VAT_AMT: txtDiscountAmount,
          PURCHASE_PRICE: Math.round(unitPrice * 10000) / 10000,
          PROFIT_AMT: gp.toFixed(2),
          PROFIT_PCT: gpPct.toFixed(2) + "%",
          TOTAL_VALUES: netTotal.toFixed(4),
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleDiscountChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        const discount = parseFloat(event.target.value) || 0;
        const totalAmount = item.TOTAL_AMOUNT || 0;
        const txtDiscountAmount = item.VAT_AMT || 0;
        const itemQtyPcs = item.ITEM_QTY || 0;
        const salesPrice = item.SALES_PRICE || 0;
        const unitPrice =
          (totalAmount + txtDiscountAmount - discount) / itemQtyPcs;

        const gp = salesPrice - unitPrice;
        const gpPct = (gp / salesPrice) * 100;

        const netTotal = unitPrice * itemQtyPcs;

        return {
          ...item,
          DISCOUNT_AMT: discount,
          PURCHASE_PRICE: Math.round(unitPrice * 10000) / 10000,
          PROFIT_AMT: gp.toFixed(2),
          PROFIT_PCT: gpPct.toFixed(2) + "%",
          TOTAL_VALUES: Math.round(netTotal * 10000) / 10000,
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleMRPChange = (event, orderItem) => {
    debugger;
    const updatedOrderItems = orderItemList.map((item) => {
      debugger;
      if (item.SL_NO === orderItem.SL_NO) {
        let mrp = parseFloat(event.target.value) || 0;

        let purchasePrice = item.PURCHASE_PRICE || 0;
        let gp = mrp - purchasePrice;
        let gPPercentage = (gp / mrp) * 100;
        if (isNaN(gPPercentage) || !isFinite(gPPercentage)) {
          gPPercentage = 0;
        }
        return {
          ...item,
          SALES_PRICE: mrp,
          PROFIT_AMT: gp.toFixed(2),
          PROFIT_PCT: gPPercentage.toFixed(2) + "%",
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleDateChange = (event, orderItem) => {
    const selectedDate = event.target.value;

    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        return { ...item, EXP_DATE: selectedDate };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleUnitPriceChange = (event, orderItem) => {
    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        debugger;
        const unitPrice = parseFloat(event.target.value) || 0;
        const vat = item.VAT_AMT || 0;
        const discount = item.DISCOUNT_AMT || 0;
        const salesPrice = item.SALES_PRICE || 0;
        const itemQtyPcs = item.ITEM_QTY || 0;

        const totalValue = unitPrice * itemQtyPcs + vat - discount;
        const gp = salesPrice - unitPrice;
        const gpPct = (gp / salesPrice) * 100;
        const netTotal = unitPrice * itemQtyPcs;

        return {
          ...item,
          PURCHASE_PRICE: Math.round(unitPrice * 10000) / 10000,
          TOTAL_AMOUNT: Math.round(totalValue * 10000) / 10000,
          PROFIT_AMT: gp.toFixed(2),
          PROFIT_PCT: gpPct.toFixed(2) + "%",
          TOTAL_VALUES: netTotal.toFixed(4),
        };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleBatchChange = (event, orderItem) => {
    const batcthNumber = event.target.value;

    const updatedOrderItems = orderItemList.map((item) => {
      if (item.SL_NO === orderItem.SL_NO) {
        return { ...item, BATCH_NUMBER: batcthNumber };
      }
      return item;
    });

    setOrderItemList(updatedOrderItems);
  };

  const handleDuplicateItem = (orderItem) => {
    const lastItem = orderItemList[orderItemList.length - 1];
    const newSL_NO = lastItem ? lastItem.SL_NO + 1 : 1;
    const duplicatedItem = { ...orderItem };
    duplicatedItem.SL_NO = newSL_NO;
    setOrderItemList([...orderItemList, duplicatedItem]);
  };

  //----------------------------------------------------------------------------

  const handleTypeSelectChange = (event) => {
    const value = event.target.value;
    setSelectedTypeValue(value);
    getTransactionList(
      value,
      selectedSerStoreValue,
      selectedSerSupplierValue,
      serarchInputValue
    );
  };

  const handleSearchInputChange = (event) => {
    setSerarchInputValue(event.target.value);
    getTransactionList(
      selectedTypeValue,
      selectedSerStoreValue,
      selectedSerSupplierValue,
      event.target.value
    );
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
  };

  const startIndex = (currentPage - 1) * transactionsPerPage;
  const endIndex = startIndex + transactionsPerPage;
  const currentTransactions = transactionList.slice(startIndex, endIndex);

  useEffect(() => {
    if (!userData) {
      navigate("/");
    }
    setLoading(true);

    // Set loading to false after 3 seconds
    const timeoutId = setTimeout(() => {
      setLoading(false);
    }, 400);

    setLoading(true);
    getSerStoreList();
    getSerSupplierList();
    getStoreList();
    getSupplierList();
    getTransactionList("-1", "-1", "-1", "");

    return () => clearTimeout(timeoutId);
  }, []);

  //#region LitView Start
  const getSerStoreList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetSrcStoreList?GID=${encodeURIComponent(
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

  const finalSerStoreList = serStoreList.map((serStore) => ({
    value: serStore?.STORE_NO || "",
    label: serStore?.STORE_NAME || "",
  }));

  const handleSerStoreChange = (selectedOption) => {
    setSelectedSerStore(selectedOption);
    setSelectedSerStoreValue(selectedOption.value);
    getTransactionList(
      selectedTypeValue,
      selectedOption.value,
      selectedSerSupplierValue,
      serarchInputValue
    );
  };

  const getSerSupplierList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetSrcSupplierList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
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

  const finalSerSupplierList = serSupplierList.map((serSupplier) => ({
    value: serSupplier?.SUPPLIER_NO || "",
    label: serSupplier?.SUPPLIER_NAME || "",
  }));

  const handleSerSupplierChange = (selectedOption) => {
    debugger;
    setSelectedSerSupplier(selectedOption);
    setSelectedSerSupplierValue(selectedOption.value);
    getTransactionList(
      selectedTypeValue,
      selectedSerStoreValue,
      selectedOption.value,
      serarchInputValue
    );
  };

  const clearFilterClick = () => {
    getTransactionList("-1", "-1", "-1", "");
    setSelectedTypeValue("-1");
    setSelectedSerStore(null);
    setSelectedSerSupplier(null);
    setSelectedSerStoreValue("-1");
    setSelectedSerSupplierValue("-1");
    setSerarchInputValue("");
  };

  const onCalculateClick = () => {
    const calculatedTotalAmount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.TOTAL_AMOUNT) || 0),
      0
    );
    setTotalAmount(calculatedTotalAmount.toFixed(4));

    const calculatedTotalVat = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.VAT_AMT) || 0),
      0
    );
    setTotalVat(calculatedTotalVat.toFixed(4));

    const calculatedTotalDiscount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.DISCOUNT_AMT) || 0),
      0
    );
    setTotalDiscount(calculatedTotalDiscount.toFixed(4));

    // const netTotal = orderItemList.reduce(
    //   (total, orderItem) => total + (parseFloat(orderItem.TOTAL_VALUES) || 0),
    //   0
    // );
    let netAmount =
      calculatedTotalAmount + calculatedTotalVat - calculatedTotalDiscount;
    setNetAmount(Math.round(netAmount * 10000) / 10000);
  };

  const getTransactionList = async (
    trnTypeValue,
    storeNoValue,
    supplierNoValue,
    serarchInputValue
  ) => {
    let approvalFlag = trnTypeValue;
    let storeNo = storeNoValue;
    let supplierNo = supplierNoValue;
    let phrTrnIdForSearch = serarchInputValue;
    let startDate = "01/01/2002";
    let endDate = "01/01/2024";
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetTransactionList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}
          &ApproveFlag=${encodeURIComponent(
            approvalFlag
          )}&StoreNo=${encodeURIComponent(storeNo)}
          &SupplierNo=${encodeURIComponent(
            supplierNo
          )}&PhrTrnIDForSearch=${encodeURIComponent(
            phrTrnIdForSearch
          )}&StartDate=${encodeURIComponent(
            startDate
          )}&EndDate=${encodeURIComponent(endDate)}`,
        { method: "GET" }
      );
      let data = await response.json();
      setTransactionList(data);
    } catch (error) {}
  };

  //#endregion ListView End

  //#region EntryView Start
  const getStoreList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetStoreList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}&UserNo=${encodeURIComponent(pin)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setStoreList(data);
    } catch (error) {
      setStoreList([]);
    }
  };

  const finalStoreList = storeList.map((store) => ({
    value: store?.STORE_NO || "",
    label: store?.STORE_NAME || "",
  }));

  const handleStoreChange = (selectedOption) => {
    setSelectedStore(selectedOption);
    setSelectedStoreValue(selectedOption.value);
  };

  const getSupplierList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetSupplierList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setSupplierList(data);
    } catch (error) {
      setSupplierList([]);
    }
  };

  const finalSupplierList = supplierList.map((supplier) => ({
    value: supplier?.SUPPLIER_NO || "",
    label: supplier?.SUPPLIER_NAME || "",
  }));

  const handleSupplierChange = (selectedOption) => {
    debugger;
    setSelectedSupplier(selectedOption);
    setSelectedSupplierValue(selectedOption.value);
    getOrderList(selectedOption.value);
  };

  const getOrderList = async (supplierValue) => {
    let startDate = "01/01/2020";
    let endDate = "01/01/2024";
    let storeNo = selectedStoreValue;
    let supplierNo = supplierValue;
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetOrderNumberList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}&StartDate=${encodeURIComponent(
            startDate
          )}
          &EndDate=${encodeURIComponent(endDate)}&StoreNo=${encodeURIComponent(
            storeNo
          )}&SupplierNo=${encodeURIComponent(supplierNo)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }

      let data = await response.json();
      setOrderList(data);
    } catch (error) {
      setOrderList([]);
    }
  };

  const finalOrderList = orderList.map((order) => ({
    value: order?.PHR_PUR_ORD_NO || "",
    label1: order?.PHR_PUR_ORD_ID || "",
    label2: order?.PUR_ORD_DATE || "",
    label3: order?.SUPPLIER_NAME || "",
    label4: order?.STORE_NAME || "",
    label5: order?.TOTAL_AMT || "",
  }));

  const handleOrderChange = (selectedOption) => {
    setSelectedOrder({
      label1: selectedOption.label1,
    });
    // setSelectedOrder(selectedOption);
    setSelectedOrderValue(selectedOption.value);
    getOrderItemList(selectedOption.value);
  };

  const getOrderItemList = async (orderNoValue) => {
    debugger;
    setLoading(true);

    let orderNo = orderNoValue;
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetOrderReceivedItemList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}&phr_pur_ord_no=${encodeURIComponent(
            orderNo
          )}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      debugger;
      let data = await response.json();
      setOrderItemList(data);
      GetTotal(data);
      setLoading(false);
    } catch (error) {
      setOrderItemList([]);
      setLoading(false);
    }
  };

  const GetTotal = (orderItemList) => {
    debugger;
    const calculatedTotalAmount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.TOTAL_AMOUNT) || 0),
      0
    );
    setTotalAmount(calculatedTotalAmount.toFixed(4));

    const calculatedTotalVat = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.VAT_AMT) || 0),
      0
    );
    setTotalVat(calculatedTotalVat.toFixed(4));

    const calculatedTotalDiscount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.DISCOUNT_AMT) || 0),
      0
    );
    debugger;
    setTotalDiscount(calculatedTotalDiscount.toFixed(4));

    // const netTotalValue = orderItemList.reduce(
    //   (total, orderItem) => total + (parseFloat(orderItem.TOTAL_VALUES) || 0),
    //   0
    // );
    let netAmount =
      calculatedTotalAmount + calculatedTotalVat - calculatedTotalDiscount;
    setNetAmount(Math.round(netAmount * 10000) / 10000);
  };

  //#endregion EntryView End

  const toggleListVisibility = () => {
    setLoading(true);
    getTransactionList("-1", "-1", "-1", "");
    clearSubmit();
    setIsListVisible(!isListVisible);
    setIsEntryVisible(false);
    setLoading(false);
  };

  const toggleEntryVisibility = () => {
    setLoading(true);
    setIsEntryVisible(!isEntryVisible);
    setIsListVisible(false);
    const today = new Date();
    const formattedDate = today.toISOString().split("T")[0];
    setSelectedFromDate(formattedDate);
    setSelectedInvoiceDate(formattedDate);
    setSelectedToDate(formattedDate);
    getReceivedByList();
    setTotalAmount(0);
    setTotalDiscount(0);
    setTotalVat(0);
    setNetAmount(0);
    setLoading(false);
    setOrderItemList([null]);
  };

  const getReceivedByList = async () => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/GetReceivedByList?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();
      setReceivedByList(data);
    } catch (error) {
      setReceivedByList([]);
    }
  };

  const finalReceivedByList = receivedByList.map((receivedBy) => ({
    value: receivedBy?.USER_NO || "",
    label: receivedBy?.USER_NAME || "",
  }));

  const handleReceivedByChange = (selectedOption) => {
    setSelectedReceivedBy(selectedOption);
    setSelectedReceivedByValue(selectedOption.value);
  };

  const clearSubmit = () => {
    setOrderItemList(null);
    setButtonText("SUBMIT");
    setInputInvoiceNoValue("");
    setTotalAmount("");
    setTotalVat("");
    setTotalDiscount("");
    setNetAmount("");
    setSelectedStore(null);
    setSelectedStoreValue(null);
    setSelectedSupplier(null);
    setSelectedSupplierValue(null);
    setSelectedOrder(null);
    setSelectedOrderValue(null);

    setSelectedReceivedBy(null);
    setSelectedReceivedByValue(null);
    setSelectedPayTypeValue(null);
    setInputTransNoValue("");
    setInputTransDateValue("");
    setInputApprovedByValue("");
    setInputApprovedDateValue("");
    setInputStatusValue("");
    setInputUserNameValue("");

    setTxtDiscountAmount("0");
    setTxtDiscountPct("");
  };

  //----------------------------------------------------------------------------
  const onSubmitClick = async () => {
    let payTypeValue = null;
    if (!selectedPayTypeValue || selectedPayTypeValue === "") {
      payTypeValue = null;
    } else {
      payTypeValue = selectedPayTypeValue;
    }

    let trnNo = "";
    if (phrTrnNo === "") {
      trnNo = "";
    } else {
      trnNo = phrTrnNo;
    }

    let trnId = "";
    if (phrTrnId === "") {
      trnId = "";
    } else {
      trnId = phrTrnId;
    }

    if (totalAmount === "" || 0) {
      alert("Please press CALCULATE button!");
      return;
    }

    if (inputInvoiceNoValue === "") {
      alert("Please Enter Invoice No.!");
      return;
    } else if (!selectedStoreValue || selectedStoreValue === "") {
      alert("Please Select Store!");
      return;
    } else if (!selectedSupplierValue || selectedSupplierValue === "") {
      alert("Please Select Supplier!");
      return;
    } else if (!selectedOrderValue || selectedOrderValue === "") {
      alert("Please Select Order!");
      return;
    } else if (!orderItemList.length || orderItemList.length === 0) {
      alert("Please Select Order!");
      return;
    }

    let receivedbyNo = null;
    if (
      !selectedReceivedByValue ||
      selectedReceivedByValue === 0 ||
      selectedReceivedByValue === undefined ||
      selectedReceivedByValue === ""
    ) {
      receivedbyNo = null;
    } else {
      receivedbyNo = selectedReceivedByValue;
    }

    let orderId = "";

    if (selectedOrder.label1 === undefined) {
      orderId = selectedOrder[0].label1;
    } else {
      orderId = selectedOrder.label1;
    }

    const calculatedTotalAmount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.TOTAL_AMOUNT) || 0),
      0
    );
    setTotalAmount(calculatedTotalAmount.toFixed(4));

    const calculatedTotalVat = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.VAT_AMT) || 0),
      0
    );
    setTotalVat(calculatedTotalVat.toFixed(4));

    const calculatedTotalDiscount = orderItemList.reduce(
      (total, orderItem) => total + (parseFloat(orderItem.DISCOUNT_AMT) || 0),
      0
    );

    setTotalDiscount(calculatedTotalDiscount.toFixed(4));

    let netAmount =
      calculatedTotalAmount + calculatedTotalVat - calculatedTotalDiscount;
    setNetAmount(Math.round(netAmount * 10000) / 10000);

    debugger;
    const isDecimal = (value) => {
      return !isNaN(value) && value % 1 !== 0;
    };

    const hasDecimalCondition = (value) => {
      return isDecimal(value);
    };

    const hasDecimalInOrderItem = (orderItem) => {
      const boxQty = orderItem?.BOX_QTY;
      const itemBoxQty = orderItem?.ITEM_BOX_QTY;
      const bonusQty = orderItem?.BONUS_QTY;

      return (
        hasDecimalCondition(boxQty) ||
        hasDecimalCondition(itemBoxQty) ||
        hasDecimalCondition(bonusQty)
      );
    };

    const isDecimalFound = orderItemList.some((orderItem) =>
      hasDecimalInOrderItem(orderItem)
    );

    if (isDecimalFound) {
      alert(
        "Decimal value (Like this : 0.00) found in Pack Size or RcvQty (Box) or Bonus Qty! Please enter round number."
      );
    } else {
      await fetch(variables.API_URL + "PhrGRN/TransactionSave", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },

        body: JSON.stringify({
          action_type: buttonText,
          curr_store_no: selectedStoreValue.toString(),
          trn_store_no: "",
          phr_pur_ord_no: selectedOrderValue.toString(),
          phr_pur_ord_id: orderId,
          pur_supplier_no: selectedSupplierValue.toString(),
          supp_invoice_no: inputInvoiceNoValue,
          supp_invoice_date: selectedInvoiceDate,

          Supp_pay_type_no: payTypeValue,
          phr_req_no: "",
          phr_req_id: "",
          ref_trn_no: "",
          ref_trn_id: "",
          ret_adjustment_amt: "",
          descr: "",
          received_by: receivedbyNo,

          TotalAmount: calculatedTotalAmount,
          TotalVat: calculatedTotalVat,
          TotalDiscount: calculatedTotalDiscount,
          NetAmount: netAmount,

          tranArrList: orderItemList,

          entryby: pin,
          cid: cid,
          gid: gid,
          Entryip: "123",
          phr_trn_no: trnNo.toString(),
          phr_trn_id: trnId,
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

        if(data4 === "1"){
          setPhrTrnNo(data1);
          setPhrTrnId(data2);
          setButtonText("UPDATE");
          alert(data3);
        }
        else{
          alert(data3);
        }
      });
    }
  };

  const onApproveClick = async () => {
    debugger;

    const isExpDateNullOrUndefined = orderItemList.some((orderItem) => {
      const expDate = orderItem?.EXP_DATE;
      const batchNumber = orderItem?.BATCH_NUMBER;
      const totalAmount = orderItem?.TOTAL_AMOUNT;

      // Check if expDate, batchNumber, or totalAmount is null, undefined, empty string, or &nbsp;
      return (
        expDate === null ||
        expDate === undefined ||
        expDate === "" ||
        expDate === "&nbsp;" ||
        batchNumber === null ||
        batchNumber === undefined ||
        batchNumber === "" ||
        batchNumber === "&nbsp;" ||
        totalAmount === null ||
        totalAmount === undefined ||
        totalAmount === "" ||
        totalAmount === "&nbsp;" ||
        totalAmount === 0 ||
        totalAmount === "0"
      );
    });

    if (isExpDateNullOrUndefined) {
      console.log("At least one EXP_DATE is null, undefined, empty, or &nbsp;");
      alert(
        "Please enter Total value, Batch & Expire Date or remove blank item!"
      );
    } else {
      await fetch(variables.API_URL + "PhrGRN/TrnApproved", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },

        body: JSON.stringify({
          action_type: 1,
          curr_store_no: selectedStoreValue.toString(),
          phr_trn_no: phrTrnNo.toString(),
          entryby: parseInt(pin),
          cid: cid,
          gid: gid,
          entryip: "1",
        }),
      })
        .then((response) => response.json())
        .then((actualData) => {
          const dataArray = JSON.parse(actualData);

          alert(dataArray);
        });
    }
  };

  const handleEditClick = (transaction) => {
    toggleEntryVisibility();
    getPhrTrnData(transaction.PHR_TRN_NO, transaction.PHR_TRN_ID);
    setButtonText("UPDATE");
  };

  const getPhrTrnData = async (phrTrnNo, phrTrnId) => {
    try {
      let response = await fetch(
        variables.API_URL +
          `PhrGRN/TransactionDataMaster?GID=${encodeURIComponent(
            gid
          )}&CID=${encodeURIComponent(cid)}&Phr_trn_no=${encodeURIComponent(
            phrTrnNo
          )}`,
        { method: "GET" }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch data from the API.");
      }
      let data = await response.json();

      setPhrTrnNo(phrTrnNo);
      setPhrTrnId(phrTrnId);

      const store = data[0].map((item) => ({
        value: item.CURR_STORE_NO,
        label: item.CURR_STORE_NAME,
      }));
      setSelectedStore(store);
      let storeNo = data[0].map((item) => item.CURR_STORE_NO);
      let convValue = storeNo[0];
      setSelectedStoreValue(convValue);

      const supplier = data[0].map((item) => ({
        value: item.SUPPLIER_NO,
        label: item.SUPPLIER_NAME,
      }));

      setSelectedSupplier(supplier);
      let suppNo = data[0].map((item) => item.SUPPLIER_NO);
      let convValue2 = suppNo[0];
      setSelectedSupplierValue(convValue2);

      debugger;
      const order = data[0].map((item) => ({
        value: item.PHR_PUR_ORD_NO,
        label1: item.PHR_PUR_ORD_ID,
      }));

      setSelectedOrder(order);

      let orderNo = data[0].map((item) => item.PHR_PUR_ORD_NO);
      let convValue3 = orderNo[0];
      setSelectedOrderValue(convValue3);

      let suppInvNo = data[0].map((item) => item.SUPP_INVOICE_NO);
      let finalValue = suppInvNo[0];
      setInputInvoiceNoValue(finalValue);

      let invDate = data[0].map((item) => item.SUPP_INVOICE_DATE);
      let finalDate = invDate[0];
      setSelectedInvoiceDate(finalDate);

      let suppType = data[0].map((item) => item.SUPP_PAY_TYPE_NO);
      let finalPayType = suppType[0];
      setSelectedPayTypeValue(finalPayType);

      setOrderItemList(data[1]);

      let transNo = data[0].map((item) => item.PHR_TRN_ID);
      let finaltransNo = transNo[0];
      setInputTransNoValue(finaltransNo);

      let transDate = data[0].map((item) => item.TRN_DATETIME);
      let finaltransDate = transDate[0];
      setInputTransDateValue(finaltransDate);

      let userName = data[0].map((item) => item.USER_NAME);
      let finaluserName = userName[0];
      setInputUserNameValue(finaluserName);

      let status = data[0].map((item) => item.TRN_STATUS);
      let finalstatus = status[0];
      setInputStatusValue(finalstatus);

      let approvedBy = data[0].map((item) => item.APPROVE_BY_NAME);
      let finalapprovedBy = approvedBy[0];
      setInputApprovedByValue(finalapprovedBy);

      let ApprovedDate = data[0].map((item) => item.APPROVE_DATE);
      let finalApprovedDate = ApprovedDate[0];
      setInputApprovedDateValue(finalApprovedDate);

      const received_by = data[0].map((item) => ({
        value: item.RECEIVED_BY,
        label: item.RECEIVED_BY_NAME,
      }));

      setSelectedReceivedBy(received_by);
      debugger;
      let receiveByNo = data[0].map((item) => item.RECEIVED_BY);

      let finalreceiveByNo = receiveByNo[0];
      setSelectedReceivedByValue(finalreceiveByNo);

      const calculatedTotalAmount = data[1].reduce(
        (total, orderItem) => total + (parseFloat(orderItem.TOTAL_AMOUNT) || 0),
        0
      );
      setTotalAmount(calculatedTotalAmount.toFixed(4));

      const calculatedTotalVat = data[1].reduce(
        (total, orderItem) => total + (parseFloat(orderItem.VAT_AMT) || 0),
        0
      );
      setTotalVat(calculatedTotalVat.toFixed(4));

      const calculatedTotalDiscount = data[1].reduce(
        (total, orderItem) => total + (parseFloat(orderItem.DISCOUNT_AMT) || 0),
        0
      );
      setTotalDiscount(calculatedTotalDiscount.toFixed(4));
      setTxtDiscountAmount(calculatedTotalDiscount.toFixed(4));

      // const netTotal = data[1].reduce(
      //   (total, orderItem) => total + (parseFloat(orderItem.TOTAL_VALUES) || 0),
      //   0
      // );
      //setNetAmount(netTotal.toFixed(4));

      let netAmount =
        calculatedTotalAmount + calculatedTotalVat - calculatedTotalDiscount;
      setNetAmount(Math.round(netAmount * 10000) / 10000);
    } catch (error) {
      setOrderItemList([]);
    }
  };

  const removeItem = (itemNo) => {
    const updatedOrderItemList = orderItemList
      .filter((item) => item.SL_NO !== itemNo)
      .map((item, index) => ({
        ...item,
        SL_NO: index + 1,
      }));
    setOrderItemList(updatedOrderItemList);
  };
  //----------------------------------------------------------------------------

  return (
    <div>
      {loading ? (
        <div className="loading-overlay">
          <div className="spinner"></div>
        </div>
      ) : (
        <div className="mainDiv" style={{ padding: "10px" }}>
          {isListVisible && (
            <div className="listView">
              <div className="card" style={{ padding: "10px" }}>
                <div className="row text-start">
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
                          <option selected value={-1}>
                            All
                          </option>
                          <option value={1}>Approved</option>
                          <option value={0}>Unapproved</option>
                          <option value={2}>Cancelled</option>
                        </select>
                      </div>
                    </div>
                  </div>
                  <div className="col-2">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Store</label>
                      </div>
                      <div className="col-8">
                        <Select
                          options={finalSerStoreList}
                          value={selectedSerStore}
                          onChange={handleSerStoreChange}
                          styles={customStyles2}
                        />
                      </div>
                    </div>
                  </div>
                  <div className="col-2">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Supplier</label>
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
                  <div className="col-3">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Search</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          value={serarchInputValue} // Bind the input value to the state
                          onChange={handleSearchInputChange}
                        ></input>
                      </div>
                    </div>
                  </div>
                  <div style={{ paddingTop: "5px" }} className="col-3 text-end">
                    <button class="button-25" onClick={clearFilterClick}>
                      CLEAR FILTER
                    </button>
                    &nbsp;&nbsp;
                    <button class="button-24" onClick={toggleEntryVisibility}>
                      NEW
                    </button>
                  </div>
                </div>
              </div>
              <div className="card" style={{ padding: "10px" }}>
                <table className="table table-striped table-bordered">
                  <thead>
                    <tr>
                      <th className="text-start My-Tag-Font-Size">
                        Transaction No
                      </th>
                      <th className="text-start My-Tag-Font-Size">
                        Trans. Date
                      </th>
                      <th className="text-start My-Tag-Font-Size">
                        Store Name
                      </th>
                      <th className="text-start My-Tag-Font-Size">
                        Supplier Name
                      </th>
                      <th className="text-start My-Tag-Font-Size">
                        Supplier Invoice
                      </th>
                      <th className="text-start My-Tag-Font-Size">Status</th>
                      <th className="text-start My-Tag-Font-Size">
                        Approved By
                      </th>
                      <th className="text-start My-Tag-Font-Size">
                        Approve Date
                      </th>
                      <th className="text-start My-Tag-Font-Size">User</th>
                      <th className="text-start My-Tag-Font-Size">
                        Net Amount
                      </th>
                      <th className="text-start My-Tag-Font-Size"></th>
                    </tr>
                  </thead>
                  <tbody>
                    {currentTransactions.map((transaction) => (
                      <tr
                        key={transaction.PHR_TRN_NO}
                        className="My-Tag-Font-Size"
                      >
                        <td className="text-start">{transaction.PHR_TRN_ID}</td>
                        <td className="text-start">
                          {transaction.TRN_DATETIME}
                        </td>
                        <td className="text-start">{transaction.STORE_NAME}</td>
                        <td className="text-start">
                          {transaction.SUPPLIER_NAME}
                        </td>
                        <td className="text-start">
                          {transaction.SUPP_INVOICE_NO}
                        </td>
                        <td className="text-start">{transaction.TRN_STATUS}</td>
                        <td className="text-start">
                          {transaction.APPROVE_BY_NAME}
                        </td>
                        <td className="text-start">
                          {transaction.APPROVE_DATE}
                        </td>
                        <td className="text-start">{transaction.USER_NAME}</td>
                        <td className="text-start">{transaction.NET_AMOUNT}</td>
                        <td className="text-end">
                          <button
                            type="button"
                            style={{
                              color: "white",
                              background: "rgb(255, 0, 0)",
                              borderRadius: "3px",
                              border: "none",
                              fontWeight: "bold",
                            }}
                            onClick={() => handleEditClick(transaction)}
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
                    {Array.from(
                      {
                        length: Math.ceil(
                          transactionList.length / transactionsPerPage
                        ),
                      },
                      (_, index) => (
                        <li
                          key={index}
                          className={`page-item ${
                            currentPage === index + 1 ? "active" : ""
                          }`}
                        >
                          <button
                            className="page-link"
                            onClick={() => handlePageChange(index + 1)}
                          >
                            {index + 1}
                          </button>
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
              <div className="card text-start" style={{ padding: "10px" }}>
                <div className="row">
                  <div className="col-md-3">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>
                          Store<span style={{ color: "red" }}>*</span>
                        </label>
                      </div>
                      <div className="col-8">
                        <Select
                          options={finalStoreList}
                          value={selectedStore}
                          onChange={handleStoreChange}
                          styles={customStyles2}
                        />
                      </div>
                    </div>

                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>
                          Supplier<span style={{ color: "red" }}>*</span>
                        </label>
                      </div>
                      <div className="col-8">
                        <Select
                          options={finalSupplierList}
                          value={selectedSupplier}
                          onChange={handleSupplierChange}
                          styles={customStyles2}
                        />
                      </div>
                    </div>

                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>
                          Order No<span style={{ color: "red" }}>*</span>
                        </label>
                      </div>
                      <div className="col-8">
                        <Select
                          options={finalOrderList}
                          value={selectedOrder}
                          onChange={handleOrderChange}
                          getOptionLabel={
                            (option) => (
                              <div className="row">
                                <div className="col-2">{option.label1}</div>
                                <div className="col-2">{option.label2}</div>
                                <div className="col-3">{option.label3}</div>
                                <div className="col-3">{option.label4}</div>
                                <div className="col-2">{option.label5}</div>
                              </div>
                            )

                            // `${option.label1}_______${option.label2}_______${option.label3}_______${option.label4}_______${option.label5}`
                          }
                          getOptionValue={(option) => option.value}
                          styles={customStyles}
                          menuPortalTarget={document.body}
                        />
                      </div>
                    </div>

                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>From Date</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="date"
                          className="form-control form-control-md"
                          value={selectedFromDate}
                          onChange={(e) => setSelectedFromDate(e.target.value)}
                        />
                      </div>
                    </div>
                  </div>
                  <div className="col-md-3">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>
                          Invoice No.<span style={{ color: "red" }}>*</span>
                        </label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          value={inputInvoiceNoValue}
                          onChange={handleInputInvoiceNoChange}
                        ></input>
                      </div>
                    </div>
                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>
                          Invoice Date
                        </label>
                      </div>
                      <div className="col-8">
                        <input
                          type="date"
                          className="form-control form-control-md"
                          value={selectedInvoiceDate}
                          onChange={(e) =>
                            setSelectedInvoiceDate(e.target.value)
                          }
                        />
                      </div>
                    </div>
                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Pay Type</label>
                      </div>
                      <div className="col-8">
                        <select
                          className="form-control form-control-md"
                          id="inputGroupSelect01"
                          onChange={handleSelectPayTypeChange} // Add the onChange event handler
                          value={selectedPayTypeValue}
                        >
                          <option selected>Choose...</option>
                          <option value={1}>Cash</option>
                          <option value={2}>Credit</option>
                          <option value={3}>After Sales</option>
                          <option value={4}>Others</option>
                        </select>
                      </div>
                    </div>
                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>To Date</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="date"
                          className="form-control form-control-md"
                          value={selectedToDate}
                          onChange={(e) => setSelectedToDate(e.target.value)}
                        />
                      </div>
                    </div>
                  </div>
                  <div className="col-md-3">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Trans. No</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          disabled
                          value={inputTransNoValue}
                          onChange={handleTransNoChange}
                        ></input>
                      </div>
                    </div>

                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Trans. Date</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          disabled
                          value={inputTransDateValue}
                          onChange={handleTransDateChange}
                        ></input>
                      </div>
                    </div>
                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>User Name</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          disabled
                          value={inputUserNameValue}
                          onChange={handleUserNameChange}
                        ></input>
                      </div>
                    </div>
                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Received by</label>
                      </div>
                      <div className="col-8">
                        <Select
                          options={finalReceivedByList}
                          value={selectedReceivedBy}
                          onChange={handleReceivedByChange}
                        />
                      </div>
                    </div>
                  </div>
                  <div className="col-md-3">
                    <div className="row">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Status</label>
                      </div>
                      <div className="col-4">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          disabled
                          value={inputStatusValue}
                          onChange={handleStatusChange}
                        ></input>
                      </div>
                      <div className="col-4 text-end">
                        <button
                          class="button-24"
                          onClick={toggleListVisibility}
                        >
                          LIST
                        </button>
                      </div>
                    </div>

                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>Approved By</label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          disabled
                          value={inputApprovedByValue}
                          onChange={handleApprovedByChange}
                        ></input>
                      </div>
                    </div>
                    <div className="row cPaddingTop">
                      <div className="col-4">
                        <label style={{ paddingTop: "5px" }}>
                          Approved Date
                        </label>
                      </div>
                      <div className="col-8">
                        <input
                          type="text"
                          className="form-control form-control-md"
                          disabled
                          value={inputApprovedDateValue}
                          onChange={handleApprovedDateChange}
                        ></input>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="card" style={{ padding: "10px" }}>
                <div
                  className="row"
                  style={{
                    paddingLeft: "10px",
                    paddingRight: "10px",
                    maxHeight: "400px",
                    overflowY: "auto",
                  }}
                >
                  <table className="table table-striped table-bordered">
                    <thead>
                      <tr>
                        <th className="text-start My-Tag-Font-Size"></th>
                        <th className="text-start My-Tag-Font-Size">Sl.</th>
                        <th className="text-start My-Tag-Font-Size">
                          Item Name
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Display Category
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Pack Size
                        </th>
                        <th className="text-start My-Tag-Font-Size">Ord Qty</th>
                        <th className="text-start My-Tag-Font-Size">
                          RcvQty (Box)
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          RcvQty (Pcs)
                        </th>

                        <th className="text-start My-Tag-Font-Size">
                          Bonus Qty
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Total Qty
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Prev. Price
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Total Value
                        </th>
                        <th className="text-start My-Tag-Font-Size">VAT</th>
                        <th className="text-start My-Tag-Font-Size">
                          Discount
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Unit Price
                        </th>
                        <th className="text-start My-Tag-Font-Size">MRP</th>
                        <th className="text-start My-Tag-Font-Size">GP</th>
                        <th className="text-start My-Tag-Font-Size">GP(%)</th>
                        <th className="text-start My-Tag-Font-Size">Batch</th>
                        <th className="text-start My-Tag-Font-Size">
                          Exp. Date
                        </th>
                        <th className="text-start My-Tag-Font-Size">
                          Net Total
                        </th>
                        <th className="text-start My-Tag-Font-Size"></th>
                      </tr>
                    </thead>
                    <tbody>
                      {orderItemList
                        ? orderItemList.map((orderItem) => (
                            <tr
                              key={orderItem?.ITEM_NO || ""}
                              //key={orderItem?.ITEM_NO || ""}
                              className={`My-Tag-Font-Size ${
                                selectedRows.includes(orderItem?.SL_NO)
                                  ? "table-active"
                                  : ""
                              }`}
                              onClick={() => handleRowClick(orderItem.SL_NO)}
                            >
                              <td className="text-start">
                                <button
                                  style={{
                                    border: "none",
                                    background: "green",
                                    fontWeight: "bold",
                                    color: "white",
                                    borderRadius: "3px",
                                  }}
                                  onClick={() => handleDuplicateItem(orderItem)}
                                >
                                  +
                                </button>
                              </td>
                              <td className="text-start">
                                {orderItem?.SL_NO ?? ""}
                              </td>
                              <td
                                style={{ width: "220px" }}
                                className="text-start"
                              >
                                {orderItem?.ITEM_NAME ?? ""}
                              </td>
                              <td className="text-start">
                                {orderItem?.CATEGORY_NAME ?? ""}
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "60px", fontWeight: "bold" }}
                                  value={orderItem?.BOX_QTY ?? "0"}
                                  onChange={(e) =>
                                    handleBoxQtyChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                {orderItem?.ORDER_QTY ?? "0"}
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "60px", fontWeight: "bold" }}
                                  value={orderItem?.ITEM_BOX_QTY ?? "0"}
                                  onChange={(e) =>
                                    handleItemBoxQtyChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                {orderItem?.ITEM_QTY ?? "0"}
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "60px", fontWeight: "bold" }}
                                  value={orderItem?.BONUS_QTY ?? "0"}
                                  onChange={(e) =>
                                    handleBonusQtyChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                {orderItem?.TOTAL_QTY ?? "0"}
                              </td>
                              <td className="text-start">
                                {orderItem?.PUR_ORD_PRICE ?? "0"}
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "100px", fontWeight: "bold" }}
                                  value={orderItem?.TOTAL_AMOUNT ?? "0"}
                                  onChange={(e) =>
                                    handleTotalValueChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "60px", fontWeight: "bold" }}
                                  value={orderItem?.VAT_AMT ?? "0"}
                                  onChange={(e) =>
                                    handleVatChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "60px", fontWeight: "bold" }}
                                  value={orderItem?.DISCOUNT_AMT ?? "0"}
                                  onChange={(e) =>
                                    handleDiscountChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "100px", fontWeight: "bold" }}
                                  value={orderItem?.PURCHASE_PRICE ?? "0"}
                                  onChange={(e) =>
                                    handleUnitPriceChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                <input
                                  type="number"
                                  className="no-spinner"
                                  style={{ width: "90px", fontWeight: "bold" }}
                                  value={orderItem?.SALES_PRICE ?? "0"}
                                  onChange={(e) =>
                                    handleMRPChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                {orderItem?.PROFIT_AMT ?? "0"}
                              </td>
                              <td className="text-start">
                                {orderItem?.PROFIT_PCT ?? "0"}
                              </td>
                              <td className="text-start">
                                <input
                                  style={{ width: "60px", fontWeight: "bold" }}
                                  value={orderItem?.BATCH_NUMBER ?? ""}
                                  onChange={(e) =>
                                    handleBatchChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                <input
                                  type="date"
                                  style={{ width: "90px", fontWeight: "bold" }}
                                  value={orderItem?.EXP_DATE ?? ""}
                                  onChange={(e) =>
                                    handleDateChange(e, orderItem)
                                  }
                                />
                              </td>
                              <td className="text-start">
                                {orderItem?.TOTAL_VALUES ?? "0"}
                              </td>

                              <td className="text-start">
                                <button
                                  style={{
                                    border: "none",
                                    background: "red",
                                    fontWeight: "bold",
                                    color: "white",
                                    borderRadius: "3px",
                                  }}
                                  onClick={() => removeItem(orderItem.SL_NO)}
                                >
                                  ×
                                </button>
                              </td>
                            </tr>
                          ))
                        : []}
                    </tbody>
                  </table>
                </div>
                <br></br>
                <div
                  className="row"
                  style={{
                    paddingTop: "0px",
                    marginRight: "5px",
                    fontWeight: "bold",
                  }}
                >
                  <div className="col-md-6 text-end">
                    <div className="row">
                      <table>
                        <tbody>
                          <tr>
                            <td>
                              Discount Amount{" "}
                              <input
                                type="text"
                                style={{
                                  textAlign: "right",
                                  fontWeight: "bold",
                                }}
                                name="txtDiscountAmount"
                                value={txtDiscountAmount}
                                onChange={handleTxtDiscountAmountChange}
                              />
                            </td>
                          </tr>
                          {/* <tr>
                        <td>
                          Discount Pct. (%){" "}
                          <input
                            style={{ textAlign: "right", fontWeight: "bold" }}
                            value={txtDiscountPct}
                            disabled
                            //onChange={handleTxtDiscountPctChange}
                          ></input>
                        </td>
                      </tr> */}
                        </tbody>
                      </table>
                    </div>
                  </div>
                  <div className="col-md-2 text-end">
                    <div className="row">
                      <table>
                        <tbody>
                          <tr>
                            <td>
                              <button
                                className="button-24"
                                style={{ width: "150px" }}
                                onClick={onCalculateClick}
                              >
                                CALCULATE
                              </button>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                  <div className="col-md-4">
                    <div className="row text-end">
                      <table>
                        <tbody>
                          <tr>
                            <td>
                              Total Amount{" "}
                              <input
                                disabled
                                value={totalAmount}
                                style={{
                                  textAlign: "right",
                                  fontWeight: "bold",
                                }}
                              ></input>
                            </td>
                          </tr>
                          <tr>
                            <td>
                              Total VAT{" "}
                              <input
                                disabled
                                value={totalVat}
                                style={{
                                  textAlign: "right",
                                  fontWeight: "bold",
                                }}
                              ></input>
                            </td>
                          </tr>
                          <tr>
                            <td>
                              Total Discount{" "}
                              <input
                                disabled
                                value={totalDiscount}
                                style={{
                                  textAlign: "right",
                                  fontWeight: "bold",
                                }}
                              ></input>
                            </td>
                          </tr>
                          <tr>
                            <td>
                              Net Amount{" "}
                              <input
                                disabled
                                value={netAmount}
                                style={{
                                  textAlign: "right",
                                  fontWeight: "bold",
                                }}
                              ></input>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
              <br></br>
              <div className="row" style={{ padding: "0px" }}>
                <div className="col-4"></div>
                <div className="col-8 text-end">
                  &nbsp;&nbsp;
                  <button class="button-24" onClick={onApproveClick}>
                    APPROVE
                  </button>
                  &nbsp;&nbsp;
                  <button class="button-24" onClick={clearSubmit}>
                    NEW
                  </button>
                  &nbsp;&nbsp;
                  <button
                    id="btnSubmit"
                    class="button-24"
                    onClick={onSubmitClick}
                  >
                    {buttonText}
                  </button>
                </div>
              </div>
              <br></br>
            </div>
          )}
        </div>
      )}
    </div>
  );
}

export default MRN;
