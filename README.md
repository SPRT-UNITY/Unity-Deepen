### Assignment Info
  
제출자 : 유호진  
  
#### 구현 목표
* 필수 사항만 구현하기에는 조금 별로 인 것 같아서 3D로 제작하되, 이전에 사용했던 코드들에 더불어 배운 것들을 활용 해보고자 함.
* 언리얼의 Character 구조와 같이 유니티에서도 플레이어의 입력을 담당하는 Player와 캐릭터의 동작이 정의되는 CharacterController, 객체의 움직임이 정의되는 Movement를 분리하여 구현하고자 함. 
* 목표를 구체적으로 정해두지 않아 코드가 왔다갔다 하고 정리가 안됨(ex. 몇 인칭 어떤 뷰인지, 조작은 어떻게 하는지 등)

#### 구현 개요
* 타이틀 씬에서 Enter 버튼을 누르면 게임 씬으로 이동, 코드 상으로 맵과 캐릭터를 생성하고 플레이어의 인풋과 캐릭터를 바인딩 해줌

#### 세부 내용
* Player, CharacterController, Movement 클래스를 분리하여 구현 --> 아직 불완전함. Player와 CharacterController에 Delegate 적용 필요
* GameScene에서는 GameScene의 Manager가 맵을 생성하고 캐릭터를 배치하도록 함 (캐릭터와 맵을 Prefab화)
* Prefab화 한 Map과 Character를 Addressable을 이용하여 관리(Local 한정)
  
  
  
#### 추가적으로 구현하고자 하는 내용
* 각 Scene의 Manager 클래스를 제네릭화 및 싱글턴화
* UI의 제네릭화
* Movement는 전략 패턴과 팩토리 메서드를 이용하여 캐릭터의 움직임에 대해 간단하게 지정 할 수 있도록 하고자 함(GroundedMovement, FloatingMovement 등) --> 팩토리는 실패
