// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'fixed_building_cost.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FixedBuildingCost _$FixedBuildingCostFromJson(Map<String, dynamic> json) {
  return FixedBuildingCost()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..amount = (json['amount'] as num)?.toDouble();
}

Map<String, dynamic> _$FixedBuildingCostToJson(FixedBuildingCost instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'amount': instance.amount,
    };
