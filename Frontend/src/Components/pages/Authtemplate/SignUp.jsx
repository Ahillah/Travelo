import photo from "../../../assets/images/RECTANGLE.png"
import G from "../../../assets/icons/GG.png"
import vector from "../../../assets/icons/Vector.png"
import hotel from "../../../assets/icons/hotel.png"
import { useNavigate } from "react-router-dom";
import "../auth.css";
import { useState } from "react";

export default function SignUp() {
  const [selected, setSelected] = useState(null);
  const navigate = useNavigate();

  const handleNext = () => {
    if (selected === "tourist") {
      navigate("/SignUPT");
    } else if (selected === "hotel") {
      navigate("/SignUpH");
    }
  };
  return (
   <div className="flex flex-row gap-[96px] mt-[5px]">
  <div>
    <img className="w-[616px] h-[816px] hidden lg:block" src={photo} />
  </div>

  <div className="w-[514px] h-[518px] flex flex-col justify-between p-4">
   
    <div>
     <div className="flex flex-row items-center gap-2">
     <p className="text-[64px] monotype-corsiva" >Travel</p>
    <img className="w-[50px] h-[46px]" src={G} />
    </div>

      <div>
        <h3 className="w-[147px] h-[48px] font-bold text-[40px]">Sign up</h3>
        <p className="w-[364px] h-[20px] text-[16px] text-[#112211] pt-[20px] ">
          Please select your account type to continue
        </p>
      </div>

      <div className="flex flex-row mt-[100px] gap-[24px]">
        <button className={`flex flex-row w-[249px] h-[122px]   border-[#444444] border-[1px] justify-center pt-[32px] rounded-[16px] ${selected === "tourist" ? "bg-[#27A599]" : "bg-white"}`} onClick={() => setSelected("tourist")}>
          <img className="w-[46px] h-[58px]" src={vector} />
          <p className="mt-[12px]">Tourist</p>
        </button>
        <button className={`flex flex-row w-[249px] h-[122px] border-[#444444] border-[1px] justify-center pt-[32px] rounded-[16px] ${selected === "hotel" ? "bg-[#27A599]" : "bg-white"}`} onClick={() => setSelected("hotel")}>
          <img src={hotel} className="w-[46px] h-[46px]" />
          <p className="mt-[12px]">Hotel</p>
        </button>
      </div>
    </div>

   
   <button className="bg-[#27A599] w-[512px] h-[48px] self-start ml-[-13px] mb-[-15px] rounded-[4px]" onClick={handleNext}>
  Next
</button>

  </div>
</div>


  );
}
