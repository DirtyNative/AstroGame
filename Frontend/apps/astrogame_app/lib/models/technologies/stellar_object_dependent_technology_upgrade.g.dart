// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stellar_object_dependent_technology_upgrade.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StellarObjectDependentTechnologyUpgrade
    _$StellarObjectDependentTechnologyUpgradeFromJson(
        Map<String, dynamic> json) {
  return StellarObjectDependentTechnologyUpgrade()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..startTime = DateTime.parse(json['startTime'] as String)
    ..endTime = DateTime.parse(json['endTime'] as String)
    ..hangfireJobId = json['hangfireJobId'] as String
    ..stellarObjectId =
        const GuidConverter().fromJson(json['stellarObjectId'] as String);
}

Map<String, dynamic> _$StellarObjectDependentTechnologyUpgradeToJson(
        StellarObjectDependentTechnologyUpgrade instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'startTime': instance.startTime.toIso8601String(),
      'endTime': instance.endTime.toIso8601String(),
      'hangfireJobId': instance.hangfireJobId,
      'stellarObjectId': const GuidConverter().toJson(instance.stellarObjectId),
    };
