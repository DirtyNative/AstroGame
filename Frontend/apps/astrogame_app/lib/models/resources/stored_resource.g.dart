// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stored_resource.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StoredResource _$StoredResourceFromJson(Map<String, dynamic> json) {
  return StoredResource()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..resourceSnapshotId =
        const GuidConverter().fromJson(json['resourceSnapshotId'] as String)
    ..amount = (json['amount'] as num).toDouble()
    ..hourlyAmount = (json['hourlyAmount'] as num).toDouble();
}

Map<String, dynamic> _$StoredResourceToJson(StoredResource instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'resourceSnapshotId':
          const GuidConverter().toJson(instance.resourceSnapshotId),
      'amount': instance.amount,
      'hourlyAmount': instance.hourlyAmount,
    };
