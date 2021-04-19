// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'fixed_building_cost.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FixedBuildingCost _$FixedBuildingCostFromJson(Map<String, dynamic> json) {
  return FixedBuildingCost()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..amount = (json['amount'] as num)?.toDouble();
}

Map<String, dynamic> _$FixedBuildingCostToJson(FixedBuildingCost instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'amount': instance.amount,
    };
