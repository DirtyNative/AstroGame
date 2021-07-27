// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'resource_amount.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResourceAmount _$ResourceAmountFromJson(Map<String, dynamic> json) {
  return ResourceAmount()
    ..amount = (json['amount'] as num).toDouble()
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String);
}

Map<String, dynamic> _$ResourceAmountToJson(ResourceAmount instance) =>
    <String, dynamic>{
      'amount': instance.amount,
      'resourceId': const GuidConverter().toJson(instance.resourceId),
    };
