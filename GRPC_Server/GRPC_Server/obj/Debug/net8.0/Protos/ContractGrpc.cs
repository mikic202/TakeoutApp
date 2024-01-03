// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Takeout {
  public static partial class TakeOutService
  {
    static readonly string __ServiceName = "takeout.TakeOutService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Signin.SigninRequest> __Marshaller_signin_SigninRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Signin.SigninRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Signin.SigninReply> __Marshaller_signin_SigninReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Signin.SigninReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Signin.RestaurantSigninRequest> __Marshaller_signin_RestaurantSigninRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Signin.RestaurantSigninRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Signin.RestaurantSigninReply> __Marshaller_signin_RestaurantSigninReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Signin.RestaurantSigninReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Register.RegisterRestaurantRequest> __Marshaller_register_RegisterRestaurantRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Register.RegisterRestaurantRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Register.RegisterRestaurantReply> __Marshaller_register_RegisterRestaurantReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Register.RegisterRestaurantReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.addDishRequest> __Marshaller_dish_addDishRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.addDishRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.addDishReply> __Marshaller_dish_addDishReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.addDishReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.modifyDishRequest> __Marshaller_dish_modifyDishRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.modifyDishRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.modifyDishReply> __Marshaller_dish_modifyDishReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.modifyDishReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.allOrdersRequest> __Marshaller_dish_allOrdersRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.allOrdersRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.allOrdersResponse> __Marshaller_dish_allOrdersResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.allOrdersResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.AllDishesRequest> __Marshaller_dish_AllDishesRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.AllDishesRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Dish.AllDishesResponse> __Marshaller_dish_AllDishesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Dish.AllDishesResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Signin.SigninRequest, global::Signin.SigninReply> __Method_Signin = new grpc::Method<global::Signin.SigninRequest, global::Signin.SigninReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Signin",
        __Marshaller_signin_SigninRequest,
        __Marshaller_signin_SigninReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Signin.RestaurantSigninRequest, global::Signin.RestaurantSigninReply> __Method_SigninRestaurant = new grpc::Method<global::Signin.RestaurantSigninRequest, global::Signin.RestaurantSigninReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SigninRestaurant",
        __Marshaller_signin_RestaurantSigninRequest,
        __Marshaller_signin_RestaurantSigninReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Register.RegisterRestaurantRequest, global::Register.RegisterRestaurantReply> __Method_RegisterRestaurant = new grpc::Method<global::Register.RegisterRestaurantRequest, global::Register.RegisterRestaurantReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RegisterRestaurant",
        __Marshaller_register_RegisterRestaurantRequest,
        __Marshaller_register_RegisterRestaurantReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Dish.addDishRequest, global::Dish.addDishReply> __Method_AddDish = new grpc::Method<global::Dish.addDishRequest, global::Dish.addDishReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddDish",
        __Marshaller_dish_addDishRequest,
        __Marshaller_dish_addDishReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Dish.modifyDishRequest, global::Dish.modifyDishReply> __Method_ModifyDish = new grpc::Method<global::Dish.modifyDishRequest, global::Dish.modifyDishReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ModifyDish",
        __Marshaller_dish_modifyDishRequest,
        __Marshaller_dish_modifyDishReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Dish.allOrdersRequest, global::Dish.allOrdersResponse> __Method_GetAllOrders = new grpc::Method<global::Dish.allOrdersRequest, global::Dish.allOrdersResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllOrders",
        __Marshaller_dish_allOrdersRequest,
        __Marshaller_dish_allOrdersResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Dish.AllDishesRequest, global::Dish.AllDishesResponse> __Method_GetAllDishes = new grpc::Method<global::Dish.AllDishesRequest, global::Dish.AllDishesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllDishes",
        __Marshaller_dish_AllDishesRequest,
        __Marshaller_dish_AllDishesResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Takeout.ContractReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of TakeOutService</summary>
    [grpc::BindServiceMethod(typeof(TakeOutService), "BindService")]
    public abstract partial class TakeOutServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Signin.SigninReply> Signin(global::Signin.SigninRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Signin.RestaurantSigninReply> SigninRestaurant(global::Signin.RestaurantSigninRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Register.RegisterRestaurantReply> RegisterRestaurant(global::Register.RegisterRestaurantRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Dish.addDishReply> AddDish(global::Dish.addDishRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Dish.modifyDishReply> ModifyDish(global::Dish.modifyDishRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Dish.allOrdersResponse> GetAllOrders(global::Dish.allOrdersRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Dish.AllDishesResponse> GetAllDishes(global::Dish.AllDishesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for TakeOutService</summary>
    public partial class TakeOutServiceClient : grpc::ClientBase<TakeOutServiceClient>
    {
      /// <summary>Creates a new client for TakeOutService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public TakeOutServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for TakeOutService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public TakeOutServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected TakeOutServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected TakeOutServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Signin.SigninReply Signin(global::Signin.SigninRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Signin(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Signin.SigninReply Signin(global::Signin.SigninRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Signin, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Signin.SigninReply> SigninAsync(global::Signin.SigninRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SigninAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Signin.SigninReply> SigninAsync(global::Signin.SigninRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Signin, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Signin.RestaurantSigninReply SigninRestaurant(global::Signin.RestaurantSigninRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SigninRestaurant(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Signin.RestaurantSigninReply SigninRestaurant(global::Signin.RestaurantSigninRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SigninRestaurant, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Signin.RestaurantSigninReply> SigninRestaurantAsync(global::Signin.RestaurantSigninRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SigninRestaurantAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Signin.RestaurantSigninReply> SigninRestaurantAsync(global::Signin.RestaurantSigninRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SigninRestaurant, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Register.RegisterRestaurantReply RegisterRestaurant(global::Register.RegisterRestaurantRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterRestaurant(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Register.RegisterRestaurantReply RegisterRestaurant(global::Register.RegisterRestaurantRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RegisterRestaurant, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Register.RegisterRestaurantReply> RegisterRestaurantAsync(global::Register.RegisterRestaurantRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterRestaurantAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Register.RegisterRestaurantReply> RegisterRestaurantAsync(global::Register.RegisterRestaurantRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RegisterRestaurant, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.addDishReply AddDish(global::Dish.addDishRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddDish(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.addDishReply AddDish(global::Dish.addDishRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddDish, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.addDishReply> AddDishAsync(global::Dish.addDishRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddDishAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.addDishReply> AddDishAsync(global::Dish.addDishRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddDish, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.modifyDishReply ModifyDish(global::Dish.modifyDishRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ModifyDish(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.modifyDishReply ModifyDish(global::Dish.modifyDishRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ModifyDish, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.modifyDishReply> ModifyDishAsync(global::Dish.modifyDishRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ModifyDishAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.modifyDishReply> ModifyDishAsync(global::Dish.modifyDishRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ModifyDish, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.allOrdersResponse GetAllOrders(global::Dish.allOrdersRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllOrders(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.allOrdersResponse GetAllOrders(global::Dish.allOrdersRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllOrders, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.allOrdersResponse> GetAllOrdersAsync(global::Dish.allOrdersRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllOrdersAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.allOrdersResponse> GetAllOrdersAsync(global::Dish.allOrdersRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllOrders, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.AllDishesResponse GetAllDishes(global::Dish.AllDishesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllDishes(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Dish.AllDishesResponse GetAllDishes(global::Dish.AllDishesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllDishes, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.AllDishesResponse> GetAllDishesAsync(global::Dish.AllDishesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllDishesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Dish.AllDishesResponse> GetAllDishesAsync(global::Dish.AllDishesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllDishes, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override TakeOutServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new TakeOutServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(TakeOutServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Signin, serviceImpl.Signin)
          .AddMethod(__Method_SigninRestaurant, serviceImpl.SigninRestaurant)
          .AddMethod(__Method_RegisterRestaurant, serviceImpl.RegisterRestaurant)
          .AddMethod(__Method_AddDish, serviceImpl.AddDish)
          .AddMethod(__Method_ModifyDish, serviceImpl.ModifyDish)
          .AddMethod(__Method_GetAllOrders, serviceImpl.GetAllOrders)
          .AddMethod(__Method_GetAllDishes, serviceImpl.GetAllDishes).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, TakeOutServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Signin, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Signin.SigninRequest, global::Signin.SigninReply>(serviceImpl.Signin));
      serviceBinder.AddMethod(__Method_SigninRestaurant, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Signin.RestaurantSigninRequest, global::Signin.RestaurantSigninReply>(serviceImpl.SigninRestaurant));
      serviceBinder.AddMethod(__Method_RegisterRestaurant, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Register.RegisterRestaurantRequest, global::Register.RegisterRestaurantReply>(serviceImpl.RegisterRestaurant));
      serviceBinder.AddMethod(__Method_AddDish, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Dish.addDishRequest, global::Dish.addDishReply>(serviceImpl.AddDish));
      serviceBinder.AddMethod(__Method_ModifyDish, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Dish.modifyDishRequest, global::Dish.modifyDishReply>(serviceImpl.ModifyDish));
      serviceBinder.AddMethod(__Method_GetAllOrders, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Dish.allOrdersRequest, global::Dish.allOrdersResponse>(serviceImpl.GetAllOrders));
      serviceBinder.AddMethod(__Method_GetAllDishes, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Dish.AllDishesRequest, global::Dish.AllDishesResponse>(serviceImpl.GetAllDishes));
    }

  }
}
#endregion
