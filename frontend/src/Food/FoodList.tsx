// import data from c# backend
import { useEffect, useState } from 'react';
import { MarriottFood } from '../Types/MarriottFood';

function FoodList() {
  // set foodData object with state (setFoodData), make initial state with blank object
  const [foodData, setFoodData] = useState<MarriottFood[]>([]);

  useEffect(() => {
    const fetchFoodData = async () => {
      // fetch info from api
      const rsp = await fetch('http://localhost:5091/MarriottFood');

      // set variable to store data
      const f = await rsp.json();

      // set object foodData state setFoodData to json info from website
      setFoodData(f);
    };

    // call function
    fetchFoodData();
  }, []);

  return (
    <>
      <div className="row">
        <h4 className="text-center">Best Marriott Food</h4>
      </div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Event Name</th>
            <th>Vendor Name</th>
            <th>Food Rating</th>
          </tr>
        </thead>
        <tbody>
          {foodData.map((f) => (
            <tr key={f.foodId}>
              <td>{f.eventName}</td>
              <td>{f.vendorName}</td>
              <td>{f.foodRating}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default FoodList;
